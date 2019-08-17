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

        static readonly Uri _filesUrl = new Uri("files", UriKind.Relative);

        static readonly Uri _notesUrl = new Uri("notes", UriKind.Relative);

        static readonly Uri _organizationsUrl = new Uri("organizations", UriKind.Relative);

        static readonly Uri _organizationFieldsUrl = new Uri("organizationFields", UriKind.Relative);

        static readonly Uri _personsUrl = new Uri("persons", UriKind.Relative);

        static readonly Uri _personFieldsUrl = new Uri("personFields", UriKind.Relative);

        static readonly Uri _pipelinesUrl = new Uri("pipelines", UriKind.Relative);

        static readonly Uri _stagesUrl = new Uri("stages", UriKind.Relative);

        static readonly Uri _usersUrl = new Uri("users", UriKind.Relative);

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
        /// return the <see cref="Uri"/> that return all the finded deals.
        /// </summary>
        /// <returns></returns>
        public static Uri DealsFind()
        {
            return new Uri("deals/find", UriKind.Relative);
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
        /// Returns the <see cref="Uri"/> for all the updates of the specified deal.
        /// </summary>
        /// <param name="id">The id of the deal</param>
        public static Uri DealUpdates(long id)
        {
            return new Uri($"deals/{id}/flow", UriKind.Relative);
        }

        /// <summary>
        /// Returns the <see cref="Uri"/> for all the followers of the specified deal.
        /// </summary>
        /// <param name="id">The id of the deal</param>
        public static Uri DealFollowers(long id)
        {
            return new Uri($"deals/{id}/followers", UriKind.Relative);
        }

        /// <summary>
        /// Returns the <see cref="Uri"/> for deleting the participant of the specified deal.
        /// </summary>
        /// <param name="id">The id of the deal</param>
        /// <param name="dealParticipantId">The id of the deal participant</param>
        public static Uri DeleteDealFollower(long id, long dealParticipantId)
        {
            return new Uri($"deals/{id}/followers/{dealParticipantId}", UriKind.Relative);
        }

        /// <summary>
        /// Returns the <see cref="Uri"/> for all the activities of the specified deal.
        /// </summary>
        /// <param name="id">The id of the deal</param>
        public static Uri DealActivities(long id)
        {
            return new Uri($"deals/{id}/activities", UriKind.Relative);
        }

        /// <summary>
        /// Returns the <see cref="Uri"/> for all the participants of the specified deal.
        /// </summary>
        /// <param name="id">The id of the deal</param>
        public static Uri DealParticipants(long id)
        {
            return new Uri($"deals/{id}/participants", UriKind.Relative);
        }

        /// <summary>
        /// Returns the <see cref="Uri"/> for deleting the participant of the specified deal.
        /// </summary>
        /// <param name="id">The id of the deal</param>
        /// <param name="dealParticipantId">The id of the deal participant</param>
        public static Uri DeleteDealParticipant(long id, long dealParticipantId)
        {
            return new Uri($"deals/{id}/participants/{dealParticipantId}", UriKind.Relative);
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

        /// <summary>
        /// Returns the <see cref="Uri"/> that returns all of the files in response to a GET request.
        /// </summary>
        /// <returns></returns>
        public static Uri Files()
        {
            return _filesUrl;
        }

        /// <summary>
        /// Returns the <see cref="Uri"/> for the specified file.
        /// </summary>
        /// <param name="id">The id of the file</param>
        public static Uri File(long id)
        {
            return new Uri($"files/{id}", UriKind.Relative);
        }

        /// <summary>
        /// Returns the <see cref="Uri"/> that returns all of the notes in response to a GET request.
        /// </summary>
        /// <returns></returns>
        public static Uri Notes()
        {
            return _notesUrl;
        }

        /// <summary>
        /// Returns the <see cref="Uri"/> for the specified note.
        /// </summary>
        /// <param name="id">The id of the note</param>
        public static Uri Note(long id)
        {
            return new Uri($"notes/{id}", UriKind.Relative);
        }

        /// <summary>
        /// Returns the <see cref="Uri"/> that returns all of the organizations in response to a GET request.
        /// </summary>
        /// <returns></returns>
        public static Uri Organizations()
        {
            return _organizationsUrl;
        }

        /// <summary>
        /// return the <see cref="Uri"/> that return all the finded organizations.
        /// </summary>
        /// <returns></returns>
        public static Uri OrganizationsFind()
        {
            return new Uri("organizations/find", UriKind.Relative);
        }

        /// <summary>
        /// Returns the <see cref="Uri"/> for the specified organization.
        /// </summary>
        /// <param name="id">The id of the organization</param>
        public static Uri Organization(long id)
        {
            return new Uri($"organizations/{id}", UriKind.Relative);
        }

        /// <summary>
        /// Returns the <see cref="Uri"/> for all the deals of the specified organization.
        /// </summary>
        /// <param name="id">The id of the organization</param>
        public static Uri OrganizationDeal(long id)
        {
            return new Uri($"organizations/{id}/deals", UriKind.Relative);
        }

        /// <summary>
        /// Returns the <see cref="Uri"/> that returns all of the organization fields in response to a GET request.
        /// </summary>
        /// <returns></returns>
        public static Uri OrganizationFields()
        {
            return _organizationFieldsUrl;
        }

        /// <summary>
        /// Returns the <see cref="Uri"/> for the specified organization field.
        /// </summary>
        /// <param name="id">The id of the organization field</param>
        public static Uri OrganizationField(long id)
        {
            return new Uri($"organizationFields/{id}", UriKind.Relative);
        }

        /// <summary>
        /// Returns the <see cref="Uri"/> that returns all of the persons in response to a GET request.
        /// </summary>
        /// <returns></returns>
        public static Uri Persons()
        {
            return _personsUrl;
        }

        /// <summary>
        /// return the <see cref="Uri"/> that return all the finded persons.
        /// </summary>
        /// <returns></returns>
        public static Uri PersonsFind()
        {
            return new Uri("persons/find", UriKind.Relative);
        }

        /// <summary>
        /// Returns the <see cref="Uri"/> for the specified person.
        /// </summary>
        /// <param name="id">The id of the person</param>
        public static Uri Person(long id)
        {
            return new Uri($"persons/{id}", UriKind.Relative);
        }

        /// <summary>
        /// Returns the <see cref="Uri"/> for all the deals of the specified person.
        /// </summary>
        /// <param name="id">The id of the person</param>
        public static Uri PersonDeal(long id)
        {
            return new Uri($"persons/{id}/deals", UriKind.Relative);
        }

        /// <summary>
        /// Returns the <see cref="Uri"/> that returns all of the person fields in response to a GET request.
        /// </summary>
        /// <returns></returns>
        public static Uri PersonFields()
        {
            return _personFieldsUrl;
        }

        /// <summary>
        /// Returns the <see cref="Uri"/> for the specified person field.
        /// </summary>
        /// <param name="id">The id of the person field</param>
        public static Uri PersonField(long id)
        {
            return new Uri($"personFields/{id}", UriKind.Relative);
        }

        /// <summary>
        /// Returns the <see cref="Uri"/> that returns all of the pipelines in response to a GET request.
        /// </summary>
        /// <returns></returns>
        public static Uri Pipelines()
        {
            return _pipelinesUrl;
        }

        /// <summary>
        /// Returns the <see cref="Uri"/> for the specified pipeline.
        /// </summary>
        /// <param name="id">The id of the pipeline</param>
        public static Uri Pipeline(long id)
        {
            return new Uri($"pipelines/{id}", UriKind.Relative);
        }

        /// <summary>
        /// Returns the <see cref="Uri"/> for all the deals of the specified pipeline.
        /// </summary>
        /// <param name="id">The id of the pipeline</param>
        public static Uri PipelineDeal(long id)
        {
            return new Uri($"pipelines/{id}/deals", UriKind.Relative);
        }

        /// <summary>
        /// Returns the <see cref="Uri"/> that returns all of the stages in response to a GET request.
        /// </summary>
        /// <returns></returns>
        public static Uri Stages()
        {
            return _stagesUrl;
        }

        /// <summary>
        /// Returns the <see cref="Uri"/> for the specified stage.
        /// </summary>
        /// <param name="id">The id of the stage</param>
        public static Uri Stage(long id)
        {
            return new Uri($"stages/{id}", UriKind.Relative);
        }

        /// <summary>
        /// Returns the <see cref="Uri"/> for all the deals of the specified stage.
        /// </summary>
        /// <param name="id">The id of the stage</param>
        public static Uri StageDeal(long id)
        {
            return new Uri($"stages/{id}/deals", UriKind.Relative);
        }

        /// <summary>
        /// Returns the <see cref="Uri"/> that returns all of the users in response to a GET request.
        /// </summary>
        /// <returns></returns>
        public static Uri Users()
        {
            return _usersUrl;
        }

        /// <summary>
        /// return the <see cref="Uri"/> that return all the finded users.
        /// </summary>
        /// <returns></returns>
        public static Uri UsersFind()
        {
            return new Uri("users/find", UriKind.Relative);
        }

        /// <summary>
        /// return the <see cref="Uri"/> that return all the finded users.
        /// </summary>
        /// <returns></returns>
        public static Uri UsersMe()
        {
            return new Uri("users/me", UriKind.Relative);
        }

        /// <summary>
        /// Returns the <see cref="Uri"/> for the specified user.
        /// </summary>
        /// <param name="id">The id of the user</param>
        public static Uri User(long id)
        {
            return new Uri($"users/{id}", UriKind.Relative);
        }

        /// <summary>
        /// Creates the relative <see cref="Uri"/> for initiating the OAuth Web login Flow
        /// </summary>
        /// <returns></returns>
        public static Uri OAuthAuthorize()
        {
            return new Uri("oauth/authorize", UriKind.Relative);
        }

        /// <summary>
        /// Creates the relative <see cref="Uri"/> to request an OAuth access token.
        /// </summary>
        /// <returns></returns>
        public static Uri OAuthAccessToken()
        {
            return new Uri("oauth/token", UriKind.Relative);
        }

        /// <summary>
        /// Creates the relative <see cref="Uri"/> to request an OAuth access token.
        /// </summary>
        /// <returns></returns>
        public static Uri OAuthRevokeToken()
        {
            return new Uri("oauth/revoke", UriKind.Relative);
        }
    }
}
