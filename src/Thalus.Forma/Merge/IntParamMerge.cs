using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Thalus.Forma.Merge.Contracts;

namespace Thalus.Forma.Merge
{
    class IntParamMerge : IMerge<IntParam>
    {
        public void Merge(IntParam target, params IntParam[] additionals)
        {
            foreach (IntParam doubleParam in additionals)
            {
                Merge(target, doubleParam);
            }
        }

        private void Merge(IntParam target, IntParam source)
        {
            if (target.Value == default(int))
            {
                target.Value = source.Value;
            }


            if (target.Meta == null && source.Meta != null)
            {
                target.Meta = JsonConvert.DeserializeObject<IntParamMeta>(JsonConvert.SerializeObject(source.Meta));
            }

            else if (target.Meta != null)
            {
                if (source.Meta != null)
                {
                    target.Meta = Merge(target.Meta, source.Meta);
                }
            }
        }

        private IntParamMeta Merge(IntParamMeta targetMeta, IntParamMeta sourceMeta)
        {
            if (targetMeta == null && sourceMeta != null)
            {
                return JsonConvert.DeserializeObject<IntParamMeta>(JsonConvert.SerializeObject(sourceMeta));
            }

            if (targetMeta == null)
            {
                return null;
            }


            if (targetMeta.Default == default(int))
            {
                targetMeta.Default = sourceMeta.Default;
            }

            if (targetMeta.DisplayText == null)
            {
                targetMeta.DisplayText = sourceMeta.DisplayText;
            }


            if (targetMeta.Ranges == null)
            {
                targetMeta.Ranges = Merge(targetMeta.Ranges, sourceMeta.Ranges);
            }

            if (targetMeta.Enum == null)
            {
                targetMeta.Enum = Merge(targetMeta.Enum, sourceMeta.Enum);
            }

            return targetMeta;
        }

        private IntRange[] Merge(IntRange[] targetMeta, IntRange[] sourceMeta)
        {
            if (targetMeta == null && sourceMeta != null)
            {
                return JsonConvert.DeserializeObject<IntRange[]>(JsonConvert.SerializeObject(sourceMeta));
            }

            if (targetMeta == null)
            {
                return null;
            }

            if (targetMeta.Length != sourceMeta.Length)
            {
                return targetMeta;
            }

            List<IntRange> pars = new List<IntRange>();
            for (int i = 0; i < targetMeta.Length; i++)
            {
                pars.Add(Merge(targetMeta[i], sourceMeta[i]));
            }

            return pars.Where(i => i != null).ToArray();
        }

        private IntRange Merge(IntRange target, IntRange source)
        {
            if (target == null && source != null)
            {
                return JsonConvert.DeserializeObject<IntRange>(JsonConvert.SerializeObject(source));
            }

            if (target == null)
            {
                return null;
            }

            if (target.Max == default(int))
            {
                target.Max = source.Max;
            }

            if (target.Min == default(int))
            {
                target.Min = source.Min;
            }
            return target;
        }

        private IntEnumMeta[] Merge(IntEnumMeta[] targetMeta, IntEnumMeta[] sourceMeta)
        {
            if (targetMeta == null && sourceMeta != null)
            {
                return JsonConvert.DeserializeObject<IntEnumMeta[]>(JsonConvert.SerializeObject(sourceMeta));
            }

            if (targetMeta == null)
            {
                return null;
            }

            if (targetMeta.Length != sourceMeta.Length)
            {
                return targetMeta;
            }

            List<IntEnumMeta> pars = new List<IntEnumMeta>();
            for (int i = 0; i < targetMeta.Length; i++)
            {
                pars.Add(Merge(targetMeta[i], sourceMeta[i]));
            }

            return pars.Where(i => i != null).ToArray();
        }

        private IntEnumMeta Merge(IntEnumMeta target, IntEnumMeta source)
        {
            if (target == null && source != null)
            {
                return JsonConvert.DeserializeObject<IntEnumMeta>(JsonConvert.SerializeObject(source));
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