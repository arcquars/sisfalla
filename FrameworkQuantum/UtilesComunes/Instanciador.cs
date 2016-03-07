using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.IO;

namespace CNDC.UtilesComunes
{
    public class Instanciador
    {
        #region Singleton
        private static Instanciador _instancia;
        static Instanciador()
        {
            _instancia = new Instanciador();
        }
        public static Instanciador Instancia
        {
            get { return _instancia; }
        }

        private Instanciador()
        {

        }
        #endregion Singleton
        Dictionary<string, Assembly> _dicEnsamblados = new Dictionary<string, Assembly>();
        public string StartupPath { get; set; }
        public T CrearInstancia<T>(string assembly, string clase)
        {
            Assembly asm = null;
            if (_dicEnsamblados.ContainsKey(assembly))
            {
                asm = _dicEnsamblados[assembly];
            }
            else
            {
                asm = Assembly.LoadFile(System.IO.Path.Combine(StartupPath, assembly + ".dll"));
                _dicEnsamblados[assembly] = asm;
            }

            T resultado = (T)asm.CreateInstance(clase);
            return resultado;
        }

        public T IntanciarPlugin<T>()
        {
            T resultado = default(T);
            DirectoryInfo di = new DirectoryInfo(StartupPath);
            FileInfo[] assemblies = di.GetFiles("*.dll");
            foreach (FileInfo assembly in assemblies)
            {
                try
                {
                    Assembly a = Assembly.LoadFrom(assembly.FullName);
                    foreach (Type type in a.GetTypes())
                    {
                        if (type.GetInterfaces().Contains(typeof(T)))
                        {
                            resultado = (T)Activator.CreateInstance(type);
                        }
                    }
                }
                catch (Exception ex)
                {
                    int i = 0;
                }
            }

            return resultado;
        }

        public List<T> IntanciarTodos<T>()
        {
            List<T> resultado = new List<T>();
            DirectoryInfo di = new DirectoryInfo(StartupPath);
            FileInfo[] assemblies = di.GetFiles("*.dll");
            foreach (FileInfo assembly in assemblies)
            {
                try
                {
                    Assembly a = Assembly.LoadFrom(assembly.FullName);
                    foreach (Type type in a.GetTypes())
                    {
                        if (type.GetInterfaces().Contains(typeof(T)))
                        {
                            T t = (T)Activator.CreateInstance(type);
                            resultado.Add(t);
                        }
                    }
                }
                catch (Exception ex)
                {
                    int i = 0;
                }
            }

            return resultado;
        }
    }
}
