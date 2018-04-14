using System;

namespace Pipedrive
{
    /// <summary>
    /// Class for retrieving Pipedrive API URLs
    /// </summary>
    public static class ApiUrls
    {
        static readonly Uri _activitiesUrl = new Uri("activities", UriKind.Relative);

        static readonly Uri _activityFieldsUrl = new Uri("activityFields", UriKind.Relative);

        static readonly Uri _activityTypesUrl = new Uri("activityTypes", UriKind.Relative);

        static readonly Uri _currenciesUrl = new Uri("currencies", UriKind.Relative);

        static readonly Uri _dealsUrl = new Uri("deals", UriKind.Relative);

        static readonly Uri _dealFieldsUrl = new Uri("dealFields", UriKind.Relative);

        /// <summary>
        /// Returns the <see cref="Uri"/> that returns all of the activities.
        /// </summary>
        /// <returns></returns>
        public static Uri Activities()
        {
            return _activitiesUrl;
        }

        /// <summary>
        /// Returns the <see cref="Uri"/> for the specified activity.
        /// </summary>
        /// <param name="id">The id of the activity</param>
        public static Uri Activity(long id)
        {
            return new Uri($"activities/{id}", UriKind.Relative);
        }

        /// <summary>
        /// Returns the <see cref="Uri"/> that returns all of the activity fields in response to a GET request.
        /// </summary>
        /// <returns></returns>
        public static Uri ActivityFields()
        {
            return _activityFieldsUrl;
        }

        /// <summary>
        /// Returns the <see cref="Uri"/> that returns all of the activity types in response to a GET request.
        /// </summary>
        /// <returns></returns>
        public static Uri ActivityTypes()
        {
            return _activityTypesUrl;
        }

        /// <summary>
        /// Returns the <see cref="Uri"/> for the specified activity type.
        /// </summary>
        /// <param name="id">The id of the activity type</param>
        public static Uri ActivityType(long id)
        {
            return new Uri($"activityTypes/{id}", UriKind.Relative);
        }

        /// <summary>
        /// Returns the <see cref="Uri"/> that returns all of the currencies in response to a GET request.
        /// </summary>
        /// <returns></returns>
        public static Uri Currencies()
        {
            return _currenciesUrl;
        }

        /// <summary>
        /// Returns the <see cref="Uri"/> that returns all of the deals in response to a GET request.
        /// </summary>
        /// <returns></returns>
        public static Uri Deals()
        {
            return _dealsUrl;
        }

        /// <summary>
        /// Returns the <see cref="Uri"/> for the specified deal.
        /// </summary>
        /// <param name="id">The id of the deal</param>
        public static Uri Deal(long id)
        {
            return new Uri($"deals/{id}", UriKind.Relative);
        }

        /// <summary>
        /// Returns the <see cref="Uri"/> that returns all of the activity fields in response to a GET request.
        /// </summary>
        /// <returns></returns>
        public static Uri DealFields()
        {
            return _dealFieldsUrl;
        }

        /// <summary>
        /// Returns the <see cref="Uri"/> for the specified deal field.
        /// </summary>
        /// <param name="id">The id of the deal field</param>
        public static Uri DealField(long id)
        {
            return new Uri($"dealFields/{id}", UriKind.Relative);
        }
    }
}
