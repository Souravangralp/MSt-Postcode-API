namespace ProductMatrix.Application.Common.Utility;

public static class ProductFilterUtility
{
    public static List<int?> GetCommonProducts(List<int?> productIds, List<int?> compareProductIds)
    {
        productIds = (productIds.Contains(9) || compareProductIds.Contains(9))
            ? ([9])
            : productIds
                .Where(id => id.HasValue)
                .Intersect(compareProductIds.Where(id => id.HasValue))
                .ToList();

        if (productIds.Count == 0)
        {
            var idsToCheck = new List<int> { (int)ProductTypes.Optimax, (int)ProductTypes.Liberal };

            foreach (var id in idsToCheck)
            {
                if (productIds.Contains(id))
                {
                    continue;
                }

                if (compareProductIds.Contains(id))
                {
                    productIds.Add(id);
                }
                else
                {
                    productIds.Add(id);
                }
            }
        }

        return productIds;
    }
}
