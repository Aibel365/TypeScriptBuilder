using System;

namespace TypeScriptBuilder
{
    public class TsExclude : Attribute
    {
    }

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Parameter)]
    public class TsAny : Attribute
    {
    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
    public class TsClass : Attribute
    {
    }

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class TsInitialize : Attribute
    {
        public readonly string Body;
        public TsInitialize(string body)
        {
            Body = body;
        }
        public TsInitialize()
        {
            Body = null;
        }
    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum)]
    public class TsMap : Attribute
    {
        public readonly string Name;
        public TsMap(string name)
        {
            Name = name;
        }
    }

    [AttributeUsage(AttributeTargets.Class)]
    public class TsFlat : Attribute
    {
    }

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class TsOptional : Attribute
    {
    }
}
