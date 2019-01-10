using Models;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SqlSugarCreater
{
    public partial class Creater : Form
    {
        private SqlSugarClient db;
        public Creater()
        {
            InitializeComponent();
        }

        private void Creater_Load(object sender, EventArgs e)
        {
            db = new SqlSugarClient(ConnectionString);
        }

        public static ConnectionConfig ConnectionString
        {
            get
            {
                //string reval = "server=.;uid=sa;pwd=sasa;database=SqlSugarTest";
                //string reval = "server=LZGX2L2;uid=info;pwd=ceri;database=LZGX2L2";
                //string reval = "Data Source=lzgx2l2;User ID=info;Password = ceri;";
                //return reval;
                return new ConnectionConfig { ConnectionString = Config.ConnectionString, DbType = SqlSugar.DbType.MySql, IsAutoCloseConnection = true };
            }
        }

        private void btnCommit_Click(object sender, EventArgs e)
        {
            string windowsPath = Path.Combine(Application.StartupPath, "Models");
            //db.ClassGenerating.CreateClassFilesByTableNames(db, windowsPath, "Models", tbTableName.Text.ToString());
            var tableName = tbTableName.Text.ToString();
            if (tableName =="")
            {
                db.DbFirst.IsCreateAttribute().CreateClassFile(windowsPath);
            }
            else
            {
                db.DbFirst.IsCreateAttribute().Where(tbTableName.Text.ToString()).CreateClassFile(windowsPath);
            }           
        }

        private void BtnQuery_Click(object sender, EventArgs e)
        {
            var users = db.Queryable<user>().ToList();
            Console.WriteLine(users.ToString());
            //List<user> users = new List<user>();
            //var userSql = users.AsQueryable().Where(u => u.id > 2);
            //Console.WriteLine("content:{0} type:{1}", userSql, userSql.GetType());
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            //Expression<Func<int, int>> expr = x => x + 1;
            //Console.WriteLine(expr.ToString());  // x=> (x + 1)

            //var lambdaExpr = expr as LambdaExpression;
            //Console.WriteLine(lambdaExpr.Body);   // (x + 1)
            //Console.WriteLine(lambdaExpr.ReturnType.ToString());  // System.Int32

            //foreach (var parameter in lambdaExpr.Parameters)
            //{
            //    Console.WriteLine("Name:{0}, Type:{1}, ", parameter.Name, parameter.Type.ToString());
            //}

            //Test2();
            //TestForLoop();
            //TestIndex();
            //TestInvoke();
            TestSwitch();
        }

        private void Test1()
        {
            List<user> users= new List<user>();
            var userSql = users.AsQueryable().Where(u => u.id > 2);   
        }

        private void Test2()
        {
            //定义表达式传入参数
            ParameterExpression number = Expression.Parameter(typeof(int), "number");
            BlockExpression myBlock = Expression.Block(
                new[] { number },
                Expression.Assign(number, Expression.Constant(5)),
                Expression.AddAssign(number, Expression.Constant(3)),
                Expression.DivideAssign(number, Expression.Constant(2))
                );

            Expression<Func<int>> myAction = Expression.Lambda<Func<int>>(myBlock);
            //myAction.Compile().Invoke();
            Console.WriteLine(myAction.Compile()());
        }

        private void TestForLoop()
        {
            LabelTarget labelBreak = Expression.Label();
            ParameterExpression loopIndex = Expression.Parameter(typeof(int), "index");

            BlockExpression block = Expression.Block(
            new[] { loopIndex },
                // 初始化loopIndex =1
                Expression.Assign(loopIndex, Expression.Constant(1)),
                 Expression.Call(
                                null,
                                typeof(Console).GetMethod("WriteLine", new Type[] { typeof(bool) }),
                       Expression.TypeIs(
        Expression.Constant("index"),
        typeof(int))),
                Expression.Loop(
                    Expression.IfThenElse(
                // if 的判断逻辑
                        Expression.LessThanOrEqual(loopIndex, Expression.Constant(10)),
                // 判断逻辑通过的代码
                        Expression.Block(
                            Expression.Call(
                                null,
                                typeof(Console).GetMethod("WriteLine", new Type[] { typeof(string) }),
                                Expression.Constant("Hello")),
                            Expression.PostIncrementAssign(loopIndex)),
                // 判断不通过的代码
                        Expression.Break(labelBreak)
                        ), labelBreak));
            // 将我们上面的代码块表达式
            Expression<Action> lambdaExpression = Expression.Lambda<Action>(block);
            lambdaExpression.Compile().Invoke();
        }
        private void TestIndex()
        {
            ParameterExpression arrayExpr = Expression.Parameter(typeof(int[]), "Array");
            ParameterExpression indexExpr = Expression.Parameter(typeof(int), "Index");
            ParameterExpression valueExpr = Expression.Parameter(typeof(int), "Value");

            Expression arrayAccessExpr = Expression.ArrayAccess(arrayExpr, indexExpr);

            Expression<Func<int[], int, int, int>> lambdaExpr = Expression.Lambda<Func<int[], int, int, int>>(
                Expression.Assign(arrayAccessExpr, Expression.Add(arrayAccessExpr, valueExpr)),
                arrayExpr,
                indexExpr,
                valueExpr
                );
            Console.WriteLine(arrayAccessExpr.ToString());
            Console.WriteLine(lambdaExpr.ToString());

            Console.WriteLine(lambdaExpr.Compile().Invoke(new[]{10,20,30},1,5));
        }

        private void TestInvoke()
        {
            Expression<Func<int, int, bool>> largeSumTest =
    (num1, num2) => (num1 + num2) > 1000;

            InvocationExpression invocationExpression = Expression.Invoke(
                largeSumTest,
                Expression.Constant(539),
                Expression.Constant(281));

            Console.WriteLine(invocationExpression.ToString());
            //Invoke((num1, num2) => ((num1 + num2) > 1000), 539, 281);
        }

        private void TestSwitch()
        {
            ParameterExpression gender = Expression.Parameter(typeof(int));

            BlockExpression myBlock =  Expression.Block(
                            Expression.Call(
                                null,
                                typeof(Console).GetMethod("WriteLine", new Type[] { typeof(string) }),
                                Expression.Constant("Hello")),
                            Expression.Constant("女11111"));

            SwitchExpression switchExpression = Expression.Switch(
                gender,
                Expression.Constant("不详"),
                Expression.SwitchCase(Expression.Constant("男"), Expression.Constant(1)),
                Expression.SwitchCase(Expression.Constant("女"), Expression.Constant(0)),
                Expression.SwitchCase(myBlock, Expression.Constant(2))
                );
            Expression<Func<int,string>> expr4 = Expression.Lambda<Func<int,string>>(switchExpression,gender);

            Console.WriteLine(expr4.Compile().Invoke(1)); //男
            Console.WriteLine(expr4.Compile().Invoke(0)); //女
            Console.WriteLine(expr4.Compile().Invoke(11)); //不详
            Console.WriteLine(expr4.Compile().Invoke(2)); //不详

        }
    }
}
