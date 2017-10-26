using Newtonsoft.Json;
using Thalus.Forma.Merge.Contracts;

namespace Thalus.Forma.Merge
{
    class GroupParamMerge : IMerge<GroupParam>
    {
        StringParamMerge _string = new StringParamMerge();
        CharParamMerge _char = new CharParamMerge();
        DoubleParamMerge _double = new DoubleParamMerge();
        IntParamMerge _int = new IntParamMerge();

        public void Merge(GroupParam target, params GroupParam[] additionals)
        {
            foreach (GroupParam additional in additionals)
            {
                Merge(target, additional);
            }
        }

        public void Merge(GroupParam target, GroupParam source)
        {
            if (target.Meta == null && source.Meta != null)
            {
                target.Meta = JsonConvert.DeserializeObject<GroupParamMeta>(JsonConvert.SerializeObject(source.Meta));
               
            }
            else if (target.Meta != null)
            {
                if (source.Meta != null)
                {
                    target.Meta = Merge(target.Meta, source.Meta);
                }
            }

            if (target.Parts == null && source.Parts != null)
            {
                target.Parts = JsonConvert.DeserializeObject<Part[]>(JsonConvert.SerializeObject(source.Parts));
            }

            if (target.Parts != null)
            {
                if (target.Parts.Length == source.Parts?.Length)
                {
                    for (int i = 0; i < target.Parts.Length; i++)
                    {
                        switch (target.Parts[i].Type)
                        {
                            case "double":
                                _double.Merge(target.Parts[i] as DoubleParam, source.Parts[i] as DoubleParam);
                                break;
                            case "int":
                                _int.Merge(target.Parts[i] as IntParam, source.Parts[i] as IntParam);
                                break;
                            case "char":
                                _char.Merge(target.Parts[i] as CharParam, source.Parts[i] as CharParam);
                                break;
                            case "string":
                                _string.Merge(target.Parts[i] as StringParam, source.Parts[i] as StringParam);
                                break;
                        }
                    }
                }
            }
        }

        private GroupParamMeta Merge(GroupParamMeta targetMeta, GroupParamMeta sourceMeta)
        {
            if (targetMeta == null && sourceMeta != null)
            {
                return JsonConvert.DeserializeObject<GroupParamMeta>(JsonConvert.SerializeObject(sourceMeta));
            }

            if (targetMeta == null)
            {
                return null;
            }
            
            if (targetMeta.DisplayText == null)
            {
                targetMeta.DisplayText = sourceMeta.DisplayText;
            }

            return targetMeta;
        }
    }
}