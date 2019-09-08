using System.Linq;

namespace DXYK.Admin.API.Utils
{
    /// <summary>
    /// CommmonUtils工具集合
    /// </summary>
    public class CommmonUtils
    {
        /// <summary>
        /// 将一个实体类复制到另一个实体类
        /// </summary>
        /// <param name="objSrc">源实体类</param>
        /// <param name="objDesc">复制到的实体类</param>
        /// <param name="ignoreFields">不复制的属性</param>
        public static void EntityToEntity(object objSrc, object objDesc, string[] ignoreFields)
        {
            var sourceType = objSrc.GetType();
            var destType = objDesc.GetType();
            foreach (var item in destType.GetProperties())
            {
                if (ignoreFields != null && ignoreFields.Any(x => x.ToUpper() == item.Name))
                {
                    continue;
                }
                object obj = sourceType.GetProperty(item.Name).GetValue(objSrc, null);
                if (obj != null)
                {
                    item.SetValue(objDesc, sourceType.GetProperty(item.Name).GetValue(objSrc, null), null);
                }
            }

        }
    }
}
