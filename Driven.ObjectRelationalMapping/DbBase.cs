 using System.Collections.Generic;
 using System.IO;
 using System.Reflection;
 using NHibernate;
 using NHibernate.ByteCode.Castle;
 using NHibernate.Cfg;
 using NHibernate.Connection;
 using NHibernate.Dialect;
 using NHibernate.Driver;
 using NUnit.Framework;

namespace Driven.ObjectRelationalMapping
{
    [TestFixture]  
    public abstract class DbBase<T>  
    {  
        protected ISessionFactory factory;  
        protected T sut;  
    
        private string dbFile;  
    
        public void Init(params Assembly[] assembliesWithMappings)  
        {  
            dbFile = GetDbFileName();  
            EnsureDbFileNotExists();  
    
            //NHibernateProfiler.Initialize();  
            var configuration = new Configuration()  
                .AddProperties(new Dictionary<string, string>  
                                   {  
                                       { Environment.ConnectionDriver, typeof( SQLite20Driver ).FullName },  
                                       { Environment.Dialect, typeof( SQLiteDialect ).FullName },  
                                       { Environment.ConnectionProvider, typeof( DriverConnectionProvider ).FullName },  
                                       { Environment.ConnectionString, string.Format( "Data Source={0};Version=3;New=True;", dbFile) },  
                                       { Environment.ProxyFactoryFactoryClass, typeof( ProxyFactoryFactory ).AssemblyQualifiedName },  
                                       { Environment.Hbm2ddlAuto, "create" },  
                                       { Environment.ShowSql, true.ToString() }  
                                   });  
            foreach (var assembly in assembliesWithMappings)  
            {  
                configuration.AddAssembly(assembly);  
            }  
    
            //new Remapper().Remap(configuration);  
    
            factory = configuration.BuildSessionFactory();  
        }  
    
        [TearDown]  
        public void TearDownTests()  
        {  
            factory.Dispose();  
            EnsureDbFileNotExists();  
            //NHibernateProfiler.Stop();  
        }  
    
        private string GetDbFileName()  
        {  
            var path = Path.GetFullPath(Path.GetRandomFileName() + ".Test.db");  
            if (!File.Exists(path))  
            {  
                return path;  
            }  
    
            // let's try again  
            return GetDbFileName();  
        }  
    
        private void EnsureDbFileNotExists()  
        {  
            if (File.Exists(dbFile))  
            {  
                File.Delete(dbFile);  
            }  
        }  
    }
}