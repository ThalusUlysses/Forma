using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Thalus.Forma.Merge.Contracts;

namespace Thalus.Forma.Merge
{
    class CharParamMerge : IMerge<CharParam>
    {
        public void Merge(CharParam target, params CharParam[] additionals)
        {
            foreach (CharParam doubleParam in additionals)
            {
                Merge(target, doubleParam);
            }
        }

        private void Merge(CharParam target, CharParam source)
        {
            if (target.Value == default(char))
            {
                target.Value = source.Value;
            }


            if (target.Meta == null && source.Meta != null)
            {
                target.Meta = JsonConvert.DeserializeObject<CharParamMeta>(JsonConvert.SerializeObject(source.Meta));
            }

            else if (target.Meta != null)
            {
                if (source.Meta != null)
                {
                    target.Meta = Merge(target.Meta, source.Meta);
                }
            }
        }

        private CharParamMeta Merge(CharParamMeta targetMeta, CharParamMeta sourceMeta)
        {
            if (targetMeta == null && sourceMeta != null)
            {
                return JsonConvert.DeserializeObject<CharParamMeta>(JsonConvert.SerializeObject(sourceMeta));
            }

            if (targetMeta == null)
            {
                return null;
            }


            if (targetMeta.Default == default(char))
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


        private CharEnumMeta[] Merge(CharEnumMeta[] targetMeta, CharEnumMeta[] sourceMeta)
        {
            if (targetMeta == null && sourceMeta != null)
            {
                return JsonConvert.DeserializeObject<CharEnumMeta[]>(JsonConvert.SerializeObject(sourceMeta));
            }

            if (targetMeta == null)
            {
                return null;
            }

            if (targetMeta.Length != sourceMeta.Length)
            {
                return targetMeta;
            }

            List<CharEnumMeta> pars = new List<CharEnumMeta>();
            for (int i = 0; i < targetMeta.Length; i++)
            {
                pars.Add(Merge(targetMeta[i], sourceMeta[i]));
            }

            return pars.Where(i => i != null).ToArray();
        }

        private CharEnumMeta Merge(CharEnumMeta target, CharEnumMeta source)
        {
            if (target == null && source != null)
            {
                return JsonConvert.DeserializeObject<CharEnumMeta>(JsonConvert.SerializeObject(source));
            }

            if (target == null)
            {
                return null;
            }

            if (target.Enum == default(int))
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