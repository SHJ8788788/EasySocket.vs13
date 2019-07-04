using Sugar.Enties;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DllBase;
public class DbContext<T> where T : class, new()
{
    public DbContext()
    {
        Db = new SqlSugarClient(new ConnectionConfig()
        {
            ConnectionString = Config.ConnectionString,
            DbType = DbType.Oracle,
            InitKeyType = InitKeyType.Attribute,//从特性读取主键和自增列信息
            IsAutoCloseConnection = true,//开启自动释放模式和EF原理一样我就不多解释了

        });
        //调式代码 用来打印SQL 
        Db.Aop.OnLogExecuting = (sql, pars) =>
        {
            Console.WriteLine(sql + "\r\n" +
                Db.Utilities.SerializeObject(pars.ToDictionary(it => it.ParameterName, it => it.Value)));
            Console.WriteLine();
        };

    }
    //注意：不能写成静态的
    public SqlSugarClient Db;//用来处理事务多表查询和复杂的操作
	public SimpleClient<T> CurrentDb { get { return new SimpleClient<T>(Db); } }//用来操作当前表的数据

   public SimpleClient<BLT_DISPOSE> BLT_DISPOSEDb { get { return new SimpleClient<BLT_DISPOSE>(Db); } }//用来处理BLT_DISPOSE表的常用操作
   public SimpleClient<BLT_DISPOSE_BAK> BLT_DISPOSE_BAKDb { get { return new SimpleClient<BLT_DISPOSE_BAK>(Db); } }//用来处理BLT_DISPOSE_BAK表的常用操作
   public SimpleClient<BLT_PROC> BLT_PROCDb { get { return new SimpleClient<BLT_PROC>(Db); } }//用来处理BLT_PROC表的常用操作
   public SimpleClient<BLT_PROC_DATA> BLT_PROC_DATADb { get { return new SimpleClient<BLT_PROC_DATA>(Db); } }//用来处理BLT_PROC_DATA表的常用操作
   public SimpleClient<BLT_PROC_HIST> BLT_PROC_HISTDb { get { return new SimpleClient<BLT_PROC_HIST>(Db); } }//用来处理BLT_PROC_HIST表的常用操作
   public SimpleClient<BLT_WEIGHT_CHK> BLT_WEIGHT_CHKDb { get { return new SimpleClient<BLT_WEIGHT_CHK>(Db); } }//用来处理BLT_WEIGHT_CHK表的常用操作
   public SimpleClient<C3_BWX_WMT03_RUN01> C3_BWX_WMT03_RUN01Db { get { return new SimpleClient<C3_BWX_WMT03_RUN01>(Db); } }//用来处理C3_BWX_WMT03_RUN01表的常用操作
   public SimpleClient<C3_BWX_WMT03_RUN02> C3_BWX_WMT03_RUN02Db { get { return new SimpleClient<C3_BWX_WMT03_RUN02>(Db); } }//用来处理C3_BWX_WMT03_RUN02表的常用操作
   public SimpleClient<CODEDT> CODEDTDb { get { return new SimpleClient<CODEDT>(Db); } }//用来处理CODEDT表的常用操作
   public SimpleClient<CURCTRA> CURCTRADb { get { return new SimpleClient<CURCTRA>(Db); } }//用来处理CURCTRA表的常用操作
   public SimpleClient<CURCTRA_1> CURCTRA_1Db { get { return new SimpleClient<CURCTRA_1>(Db); } }//用来处理CURCTRA_1表的常用操作
   public SimpleClient<CURSET> CURSETDb { get { return new SimpleClient<CURSET>(Db); } }//用来处理CURSET表的常用操作
   public SimpleClient<CURSHIFT> CURSHIFTDb { get { return new SimpleClient<CURSHIFT>(Db); } }//用来处理CURSHIFT表的常用操作
   public SimpleClient<DOWNTIME> DOWNTIMEDb { get { return new SimpleClient<DOWNTIME>(Db); } }//用来处理DOWNTIME表的常用操作
   public SimpleClient<ERRRECORD> ERRRECORDDb { get { return new SimpleClient<ERRRECORD>(Db); } }//用来处理ERRRECORD表的常用操作
   public SimpleClient<H5X201> H5X201Db { get { return new SimpleClient<H5X201>(Db); } }//用来处理H5X201表的常用操作
   public SimpleClient<H5X201_BAK1> H5X201_BAK1Db { get { return new SimpleClient<H5X201_BAK1>(Db); } }//用来处理H5X201_BAK1表的常用操作
   public SimpleClient<H5X202> H5X202Db { get { return new SimpleClient<H5X202>(Db); } }//用来处理H5X202表的常用操作
   public SimpleClient<H5X20A> H5X20ADb { get { return new SimpleClient<H5X20A>(Db); } }//用来处理H5X20A表的常用操作
   public SimpleClient<INTERFACE_TAB_COL_CONFIG> INTERFACE_TAB_COL_CONFIGDb { get { return new SimpleClient<INTERFACE_TAB_COL_CONFIG>(Db); } }//用来处理INTERFACE_TAB_COL_CONFIG表的常用操作
   public SimpleClient<INTERFACE_TAB_COL_CONFIG_BAK> INTERFACE_TAB_COL_CONFIG_BAKDb { get { return new SimpleClient<INTERFACE_TAB_COL_CONFIG_BAK>(Db); } }//用来处理INTERFACE_TAB_COL_CONFIG_BAK表的常用操作
   public SimpleClient<INTERFACE_TEL_CONFIG_INFO> INTERFACE_TEL_CONFIG_INFODb { get { return new SimpleClient<INTERFACE_TEL_CONFIG_INFO>(Db); } }//用来处理INTERFACE_TEL_CONFIG_INFO表的常用操作
   public SimpleClient<INTERFACE_TEL_RECEIVE> INTERFACE_TEL_RECEIVEDb { get { return new SimpleClient<INTERFACE_TEL_RECEIVE>(Db); } }//用来处理INTERFACE_TEL_RECEIVE表的常用操作
   public SimpleClient<ITF_PARA_VALUE> ITF_PARA_VALUEDb { get { return new SimpleClient<ITF_PARA_VALUE>(Db); } }//用来处理ITF_PARA_VALUE表的常用操作
   public SimpleClient<LABELCOUNTER> LABELCOUNTERDb { get { return new SimpleClient<LABELCOUNTER>(Db); } }//用来处理LABELCOUNTER表的常用操作
   public SimpleClient<PRIDATA> PRIDATADb { get { return new SimpleClient<PRIDATA>(Db); } }//用来处理PRIDATA表的常用操作
   public SimpleClient<PRIDATA_BAK> PRIDATA_BAKDb { get { return new SimpleClient<PRIDATA_BAK>(Db); } }//用来处理PRIDATA_BAK表的常用操作
   public SimpleClient<PRIDATA_HIST> PRIDATA_HISTDb { get { return new SimpleClient<PRIDATA_HIST>(Db); } }//用来处理PRIDATA_HIST表的常用操作
   public SimpleClient<PRIDATA_WT> PRIDATA_WTDb { get { return new SimpleClient<PRIDATA_WT>(Db); } }//用来处理PRIDATA_WT表的常用操作
   public SimpleClient<PRINTTMP> PRINTTMPDb { get { return new SimpleClient<PRINTTMP>(Db); } }//用来处理PRINTTMP表的常用操作
   public SimpleClient<P_DATA> P_DATADb { get { return new SimpleClient<P_DATA>(Db); } }//用来处理P_DATA表的常用操作
   public SimpleClient<P_DATA_MILL> P_DATA_MILLDb { get { return new SimpleClient<P_DATA_MILL>(Db); } }//用来处理P_DATA_MILL表的常用操作
   public SimpleClient<P_DATA_RF> P_DATA_RFDb { get { return new SimpleClient<P_DATA_RF>(Db); } }//用来处理P_DATA_RF表的常用操作
   public SimpleClient<ROLLMNG> ROLLMNGDb { get { return new SimpleClient<ROLLMNG>(Db); } }//用来处理ROLLMNG表的常用操作
   public SimpleClient<SERVERLOG> SERVERLOGDb { get { return new SimpleClient<SERVERLOG>(Db); } }//用来处理SERVERLOG表的常用操作
   public SimpleClient<TABLE_FOR_TEST> TABLE_FOR_TESTDb { get { return new SimpleClient<TABLE_FOR_TEST>(Db); } }//用来处理TABLE_FOR_TEST表的常用操作
   public SimpleClient<TOAD_PLAN_TABLE> TOAD_PLAN_TABLEDb { get { return new SimpleClient<TOAD_PLAN_TABLE>(Db); } }//用来处理TOAD_PLAN_TABLE表的常用操作
   public SimpleClient<USERINFO> USERINFODb { get { return new SimpleClient<USERINFO>(Db); } }//用来处理USERINFO表的常用操作
   public SimpleClient<X2H501> X2H501Db { get { return new SimpleClient<X2H501>(Db); } }//用来处理X2H501表的常用操作
   public SimpleClient<X2H501_BAK> X2H501_BAKDb { get { return new SimpleClient<X2H501_BAK>(Db); } }//用来处理X2H501_BAK表的常用操作
   public SimpleClient<X2H502> X2H502Db { get { return new SimpleClient<X2H502>(Db); } }//用来处理X2H502表的常用操作
   public SimpleClient<X2H502_BAK> X2H502_BAKDb { get { return new SimpleClient<X2H502_BAK>(Db); } }//用来处理X2H502_BAK表的常用操作
   public SimpleClient<X2H503> X2H503Db { get { return new SimpleClient<X2H503>(Db); } }//用来处理X2H503表的常用操作
   public SimpleClient<X2H503_BAK1> X2H503_BAK1Db { get { return new SimpleClient<X2H503_BAK1>(Db); } }//用来处理X2H503_BAK1表的常用操作
   public SimpleClient<X2H504> X2H504Db { get { return new SimpleClient<X2H504>(Db); } }//用来处理X2H504表的常用操作
   public SimpleClient<X2H504_BAK> X2H504_BAKDb { get { return new SimpleClient<X2H504_BAK>(Db); } }//用来处理X2H504_BAK表的常用操作
   public SimpleClient<X2H504_WEIGHT> X2H504_WEIGHTDb { get { return new SimpleClient<X2H504_WEIGHT>(Db); } }//用来处理X2H504_WEIGHT表的常用操作
   public SimpleClient<X2H505> X2H505Db { get { return new SimpleClient<X2H505>(Db); } }//用来处理X2H505表的常用操作
   public SimpleClient<X2H506> X2H506Db { get { return new SimpleClient<X2H506>(Db); } }//用来处理X2H506表的常用操作
   public SimpleClient<X2H509> X2H509Db { get { return new SimpleClient<X2H509>(Db); } }//用来处理X2H509表的常用操作
   public SimpleClient<X2H50A> X2H50ADb { get { return new SimpleClient<X2H50A>(Db); } }//用来处理X2H50A表的常用操作
   public SimpleClient<MAINPDI> MAINPDIDb { get { return new SimpleClient<MAINPDI>(Db); } }//用来处理MAINPDI表的常用操作


   /// <summary>
    /// 获取所有
    /// </summary>
    /// <returns></returns>
    public virtual List<T> GetList()
    {
        return CurrentDb.GetList();
    }

    /// <summary>
    /// 根据表达式查询
    /// </summary>
    /// <returns></returns>
    public virtual List<T> GetList(Expression<Func<T, bool>> whereExpression)
    {
        return CurrentDb.GetList(whereExpression);
    }


    /// <summary>
    /// 根据表达式查询分页
    /// </summary>
    /// <returns></returns>
    public virtual List<T> GetPageList(Expression<Func<T, bool>> whereExpression, PageModel pageModel)
    {
        return CurrentDb.GetPageList(whereExpression, pageModel);
    }

    /// <summary>
    /// 根据表达式查询分页并排序
    /// </summary>
    /// <param name="whereExpression">it</param>
    /// <param name="pageModel"></param>
    /// <param name="orderByExpression">it=>it.id或者it=>new{it.id,it.name}</param>
    /// <param name="orderByType">OrderByType.Desc</param>
    /// <returns></returns>
    public virtual List<T> GetPageList(Expression<Func<T, bool>> whereExpression, PageModel pageModel, Expression<Func<T, object>> orderByExpression = null, OrderByType orderByType = OrderByType.Asc)
    {
        return CurrentDb.GetPageList(whereExpression, pageModel,orderByExpression,orderByType);
    }


    /// <summary>
    /// 根据主键查询
    /// </summary>
    /// <returns></returns>
    public virtual List<T> GetById(dynamic id)
    {
        return CurrentDb.GetById(id);
    }

    /// <summary>
    /// 根据主键删除
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public virtual bool Delete(dynamic id)
    {
        return CurrentDb.Delete(id);
    }


    /// <summary>
    /// 根据实体删除
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public virtual bool Delete(T data)
    {
        return CurrentDb.Delete(data);
    }

    /// <summary>
    /// 根据主键删除
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public virtual bool Delete(dynamic[] ids)
    {
        return CurrentDb.AsDeleteable().In(ids).ExecuteCommand()>0;
    }

    /// <summary>
    /// 根据表达式删除
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public virtual bool Delete(Expression<Func<T, bool>> whereExpression)
    {
        return CurrentDb.Delete(whereExpression);
    }


    /// <summary>
    /// 根据实体更新，实体需要有主键
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public virtual bool Update(T obj)
    {
        return CurrentDb.Update(obj);
    }

    /// <summary>
    ///批量更新
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public virtual bool Update(List<T> objs)
    {
        return CurrentDb.UpdateRange(objs);
    }

    /// <summary>
    /// 插入
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public virtual bool Insert(T obj)
    {
        return CurrentDb.Insert(obj);
    }


    /// <summary>
    /// 批量
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public virtual bool Insert(List<T> objs)
    {
        return CurrentDb.InsertRange(objs);
    }


    //自已扩展更多方法 
}


