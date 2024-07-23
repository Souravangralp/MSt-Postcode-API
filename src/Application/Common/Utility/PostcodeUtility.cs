namespace MSt_Postcode_API.Application.Common.Utility;

public static class PostcodeUtility
{
    #region Methods

    /// <summary>
    /// This method is used to bind the postcode classification with a suitable postcode.
    /// It returns the postcodeClassification mapper.
    /// </summary>
    /// <param name="postcodeClassifications"></param>
    /// <returns>postcodeClassificationMapper</returns>
    public static List<PostcodeClassificationMapper> GetPostcodeClassificationMapper(List<PostcodeClassificationDto> postcodeClassifications)
    {
        List<PostcodeClassificationMapper> postcodeClassificationMapper = [];

        var postcodeRange = (int)PostcodeConfiguration.PostcodeRange;

        for (int i = 0; i < postcodeRange; i++)
        {
            foreach (var pc in postcodeClassifications)
            {
                if (pc.RangeFrom <= i && pc.RangeTo >= i)
                {
                    postcodeClassificationMapper.AddRange(new List<PostcodeClassificationMapper>()
                        {
                            new()
                            {
                                PostcodeClassificationMapper_PostcodeID = (i + 1), // ----> (i + 1) because the iteration starts from 0.
                                PostcodeClassificationMapper_PostcodeClassificationID = pc.Classification1,
                            },
                            new()
                            {
                                PostcodeClassificationMapper_PostcodeID = (i + 1),  // ----> (i + 1) because the iteration starts from 0.
                                PostcodeClassificationMapper_PostcodeClassificationID = pc.Classification2,
                            }
                        });

                    if (pc.Classification3 > 0)  // ----> checking if classification3 is not 0.
                    {
                        postcodeClassificationMapper.Add(new()
                        {
                            PostcodeClassificationMapper_PostcodeID = (i + 1), // ----> (i + 1) because the iteration starts from 0.
                            PostcodeClassificationMapper_PostcodeClassificationID = pc.Classification3
                        });
                    }
                    if (pc.Classification4 > 0)  // ----> checking if classification3 is not 0.
                    {
                        postcodeClassificationMapper.Add(new()
                        {
                            PostcodeClassificationMapper_PostcodeID = (i + 1), // ----> (i + 1) because the iteration starts from 0.
                            PostcodeClassificationMapper_PostcodeClassificationID = pc.Classification4
                        });
                    }
                }
            }
        }

        return postcodeClassificationMapper;
    }

    /// <summary>
    /// This method is used to separate the classification based on classification types
    /// It return the filtered classification id's.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="classifications"></param>
    /// <returns>int[]</returns>
    public static List<int> GetClassification(UpdatePostcodeClassificationCommand request, List<PostcodeClassification> classifications)
    {
        List<int> classificationIds = [];

        foreach (var classification in classifications)
        {
            if (request.HighSecurity is not null && request.HighSecurity.Any())
            {
                foreach (var highSecurity in request.HighSecurity)
                {
                    if (classification.Value.Replace(" ", "").ToLower() == highSecurity.Replace(" ", "").ToLower())
                    {
                        classificationIds.Add(classification.ID);
                    }
                }
            }

            if (classification.Value.Replace(" ", "").ToLower() == request.PCCategory.Replace(" ", "").ToLower() ||
                       classification.Value.Replace(" ", "").ToLower() == request.StandardAndPoor.Replace(" ", "").ToLower())
            {
                classificationIds.Add(classification.ID);
            }
        }

        return classificationIds;
    }

    #endregion
}
