using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Thalus.Forma.Merge.Contracts;

namespace Thalus.Forma.Merge
{
    class StringParamMerge : IMerge<StringParam>
    {
        public void Merge(StringParam target, params StringParam[] additionals)
        {
            foreach (StringParam doubleParam in additionals)
            {
                Merge(target, doubleParam);
            }
        }

        private void Merge(StringParam target, StringParam source)
        {
            if (target.Value == default(string))
            {
                target.Value = source.Value;
            }


            if (target.Meta == null && source.Meta != null)
            {
                target.Meta = JsonConvert.DeserializeObject<StringParamMeta>(JsonConvert.SerializeObject(source.Meta));
            }

            else if (target.Meta != null)
            {
                if (source.Meta != null)
                {
                    target.Meta = Merge(target.Meta, source.Meta);
                }
            }
        }

        private StringParamMeta Merge(StringParamMeta targetMeta, StringParamMeta sourceMeta)
        {
            if (targetMeta == null && sourceMeta != null)
            {
                return JsonConvert.DeserializeObject<StringParamMeta>(JsonConvert.SerializeObject(sourceMeta));
            }

            if (targetMeta == null)
            {
                return null;
            }


            if (targetMeta.Default == default(string))
            {
                targetMeta.Default = sourceMeta.Default;
            }

            if (targetMeta.DisplayText == null)
            {
                targetMeta.DisplayText = sourceMeta.DisplayText;
            }

            if (targetMeta.Regex == null)
            {
                targetMeta.Regex = sourceMeta.Regex;
            }

            if (targetMeta.Enum == null)
            {
                targetMeta.Enum = Merge(targetMeta.Enum, sourceMeta.Enum);
            }

            return targetMeta;
        }


        private StringEnumMeta[] Merge(StringEnumMeta[] targetMeta, StringEnumMeta[] sourceMeta)
        {
            if (targetMeta == null && sourceMeta != null)
            {
                return JsonConvert.DeserializeObject<StringEnumMeta[]>(JsonConvert.SerializeObject(sourceMeta));
            }

            if (targetMeta == null)
            {
                return null;
            }

            if (targetMeta.Length != sourceMeta.Length)
            {
                return targetMeta;
            }

            List<StringEnumMeta> pars = new List<StringEnumMeta>();
            for (int i = 0; i < targetMeta.Length; i++)
            {
                pars.Add(Merge(targetMeta[i], sourceMeta[i]));
            }

            return pars.Where(i => i != null).ToArray();
        }

        private StringEnumMeta Merge(StringEnumMeta target, StringEnumMeta source)
        {
            if (target == null && source != null)
            {
                return JsonConvert.DeserializeObject<StringEnumMeta>(JsonConvert.SerializeObject(source));
            }

            if (target == null)
            {
                return null;
            }

            if (target.Enum == default(string))
            {
                target.Enum = source.Enum;
            }

            if (target.DisplayText == null)
            {
                target.DisplayText = source.DisplayText;
            }
            return target;
        }
    }
}