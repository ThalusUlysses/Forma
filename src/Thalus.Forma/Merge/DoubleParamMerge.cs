using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Thalus.Forma.Merge.Contracts;

namespace Thalus.Forma.Merge
{
    class DoubleParamMerge : IMerge<DoubleParam>
    {
        public void Merge(DoubleParam target, params DoubleParam[] additionals)
        {
            foreach (DoubleParam doubleParam in additionals)
            {
                Merge(target, doubleParam);
            }
        }

        private void Merge(DoubleParam target, DoubleParam source)
        {
            if (target.Value == default(double))
            {
                target.Value = source.Value;
            }


            if (target.Meta == null && source.Meta != null)
            {
                target.Meta = JsonConvert.DeserializeObject<DoubleParamMeta>(JsonConvert.SerializeObject(source.Meta));
            }

            else if (target.Meta != null)
            {
                if (source.Meta != null)
                {
                    target.Meta = Merge(target.Meta, source.Meta);
                }
            }
        }

        private DoubleParamMeta Merge(DoubleParamMeta targetMeta, DoubleParamMeta sourceMeta)
        {
            if (targetMeta == null && sourceMeta != null)
            {
                return JsonConvert.DeserializeObject<DoubleParamMeta>(JsonConvert.SerializeObject(sourceMeta));
            }

            if (targetMeta == null)
            {
                return null;
            }


            if (targetMeta.Default == default(double))
            {
                targetMeta.Default = sourceMeta.Default;
            }

            if (targetMeta.DisplayText == null)
            {
                targetMeta.DisplayText = sourceMeta.DisplayText;
            }

            if (targetMeta.Precision == default(int))
            {
                targetMeta.Precision = sourceMeta.Precision;
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

        private DoubleRange[] Merge(DoubleRange[] targetMeta, DoubleRange[] sourceMeta)
        {
            if (targetMeta == null && sourceMeta != null)
            {
                return JsonConvert.DeserializeObject<DoubleRange[]>(JsonConvert.SerializeObject(sourceMeta));
            }

            if (targetMeta == null)
            {
                return null;
            }

            if (targetMeta.Length != sourceMeta.Length)
            {
                return targetMeta;
            }

            List<DoubleRange> pars  = new List<DoubleRange>();
            for (int i = 0; i < targetMeta.Length; i++)
            {
                pars.Add(Merge(targetMeta[i], sourceMeta[i]));
            }

            return pars.Where(i => i != null).ToArray();
        }

        private DoubleRange Merge(DoubleRange target, DoubleRange source)
        {
            if (target == null && source != null)
            {
                return JsonConvert.DeserializeObject<DoubleRange>(JsonConvert.SerializeObject(source));
            }

            if (target == null)
            {
                return null;
            }

            if (target.Max == default(double))
            {
                target.Max = source.Max;
            }

            if (target.Min == default(double))
            {
                target.Min = source.Min;
            }
            return target;
        }

        private DoubleEnumMeta[] Merge(DoubleEnumMeta[] targetMeta, DoubleEnumMeta[] sourceMeta)
        {
            if (targetMeta == null && sourceMeta != null)
            {
                return JsonConvert.DeserializeObject<DoubleEnumMeta[]>(JsonConvert.SerializeObject(sourceMeta));
            }

            if (targetMeta == null)
            {
                return null;
            }

            if (targetMeta.Length != sourceMeta.Length)
            {
                return targetMeta;
            }

            List<DoubleEnumMeta> pars = new List<DoubleEnumMeta>();
            for (int i = 0; i < targetMeta.Length; i++)
            {
                pars.Add(Merge(targetMeta[i], sourceMeta[i]));
            }

            return pars.Where(i => i != null).ToArray();
        }

        private DoubleEnumMeta Merge(DoubleEnumMeta target, DoubleEnumMeta source)
        {
            if (target == null && source != null)
            {
                return JsonConvert.DeserializeObject<DoubleEnumMeta>(JsonConvert.SerializeObject(source));
            }

            if (target == null)
            {
                return null;
            }

            if (target.Enum == default(double))
            {
                target.Enum = source.Enum;
            }

            if (target.DisplayText ==null)
            {
                target.DisplayText = source.DisplayText;
            }
            return target;
        }
    }
}
