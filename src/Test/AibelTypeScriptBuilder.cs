using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using TypeScriptBuilder;

namespace Test
{
    public static class AibelTypeScriptBuilder
    {
        public static void CreateTypeScriptFiles()
        {
            try
            {
                CreateTypeScriptFile(["Test.Models"], "template/index.ts");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static void CreateTypeScriptFile(List<string> nameSpaces, string name)
        {
            var ts = new TypeScriptGenerator(new TypeScriptGeneratorOptions
            {
                IgnoreNamespaces = true,
                EmitIinInterface = true,
                EmitDocumentation = false
            });

            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            if (path == null)
                return;

            var assemblies = Directory.GetFiles(path, "*.dll").Select(Assembly.LoadFile).ToList();

            foreach (var types in assemblies.Select(assembly => assembly.GetTypes().Where(x => x.IsClass && !string.IsNullOrEmpty(x.Namespace) && nameSpaces.Any(y => x.Namespace.Contains(y)))))
            {
                foreach (var type in types)
                {
                    ts.AddCsType(type);
                }
            }

            ts.Store(name);
        }
    }
}
