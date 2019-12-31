using System.Collections.Generic;

namespace client_generator.Generators
{
    public class TsGenerator
    {

        private static readonly string TypeFile = "types";

        private static readonly string MainFile = "main";

        private readonly HashSet<string> _generatedSchemes = new HashSet<string>();

        private readonly Dictionary<string, TsFile> _generatedCode = new Dictionary<string, TsFile>();

        private readonly GeneratorSetting _generatorSetting;

        public TsGenerator(GeneratorSetting generatorSetting)
        {
            _generatorSetting = generatorSetting;
        }

        // public void GenerateSchema(ISchema schema)
        // {
        //     if (isSimpleType(schema.GetSchemaType()))
        //     {
        //         return;
        //     }
        //
        //     if (schema.GetSchemaType() == SchemaType.Array)
        //     {
        //         foreach (var relatedScheme in schema.GetRelatedSchemes())
        //         {
        //             GenerateSchema(relatedScheme);
        //         }
        //
        //         return;
        //     }
        //
        //     if (schema.GetSchemaType() == SchemaType.Object)
        //     {
        //         if (_generatedSchemes.Contains(schema.GetName()))
        //         {
        //             return;
        //         }
        //
        //         foreach (var relatedScheme in schema.GetRelatedSchemes())
        //         {
        //             GenerateSchema(relatedScheme);
        //         }
        //
        //         TsFile file;
        //
        //         if (_generatorSetting.SchemePlace == SchemeGeneratePlace.WithCode)
        //         {
        //             file = GetFile(MainFile);
        //         }
        //         else if (_generatorSetting.SchemePlace == SchemeGeneratePlace.SeparatedFile)
        //         {
        //             file = GetFile(TypeFile);
        //         }
        //         else
        //         {
        //             file = GetFile(schema.GetName());
        //         }
        //
        //         file.Export(schema.GetName());
        //
        //         schema.GetRelatedSchemes()
        //             .Where(relatedSchema => relatedSchema.GetSchemaType() == SchemaType.Object).ToList().ForEach(
        //                 relatedSchema =>
        //                 {
        //                     file.Export(relatedSchema.GetName());
        //
        //                     var importFile = GetImportFile(relatedSchema);
        //                     if (importFile != null)
        //                     {
        //                         file.Import(relatedSchema.GetName(), importFile);
        //                     }
        //                 });
        //
        //         var code = GenerateCodeForCodeSchema(schema);
        //         if (code != null)
        //         {
        //             file.Write(code);
        //         }
        //
        //         _generatedSchemes.Add(schema.GetName());
        //         return;
        //     }
        //
        //     throw new ArgumentException("Unknown schema type");
        // }
        //
        // public string GetImportFile(ISchema schema)
        // {
        //     if (_generatorSetting.SchemePlace == SchemeGeneratePlace.WithCode)
        //     {
        //         return null;
        //     }
        //
        //     if (_generatorSetting.SchemePlace == SchemeGeneratePlace.SeparatedFile)
        //     {
        //         return "types";
        //     }
        //
        //     return schema.GetName();
        // }
        //
        // public string GenerateCodeForCodeSchema(ISchema schema)
        // {
        //     var model = schema.CodeModel();
        //     return model?.TransformText();
        // }
        //
        // public TsFile GetFile(string name)
        // {
        //     if (!_generatedCode.ContainsKey(name))
        //     {
        //         _generatedCode[name] = new TsFile();
        //     }
        //
        //     return _generatedCode[name];
        // }
        //
        // private static bool isSimpleType(SchemaType type)
        // {
        //     return type == SchemaType.Bool || type == SchemaType.Int || type == SchemaType.String ||
        //            type == SchemaType.Number;
        // }

    }
}
