# Pipedrive.net ![](https://github.com/DavidRouyer/pipedrive-dotnet/workflows/.NET%20Core%20CI/badge.svg)

## Getting started

### Set the API Key and URL for your project

In your application initialization, set your API key and organization URL:

```csharp
PipedriveClient client = new PipedriveClient(new ProductHeaderValue("PipedriveExample"), new Uri("[your organization url here]"))
{
  Credentials = new Credentials("[your api key here]", AuthenticationType.ApiToken)
};
```

You can obtain your secret API key from the API Settings `https://[your organization].pipedrive.com/settings/api` in Pipedrive.

## Debugging

You can debug this library right from your application by configuring the [NuGet symbol server](https://docs.microsoft.com/en-us/nuget/create-packages/symbol-packages-snupkg#nugetorg-symbol-server).

## Supported endpoints

- [x] Activities
  - [x] getActivities
  - [x] getActivity
  - [x] addActivity
  - [x] updateActivity
  - [x] deleteActivities
  - [x] deleteActivity

- [x] ActivityFields
  - [x] getActivityFields

- [x] ActivityTypes
  - [x] getActivityTypes
  - [x] addActivityType
  - [x] updateActivityType
  - [x] deleteActivityTypes
  - [x] deleteActivityType

- [ ] CallLogs
  - [ ] getUserCallLogs
  - [ ] getCallLog
  - [ ] addCallLog
  - [ ] addCallLogAudioFile
  - [ ] deleteCallLog

- [x] Currencies
  - [x] getCurrencies

- [ ] Deals
  - [x] getDeals
  - [x] searchDeals
  - [x] getDealsSummary
  - [x] getDealsTimeline
  - [x] getDeal
  - [x] getDealActivities
  - [x] getDealFiles
  - [x] getDealUpdates
  - [x] getDealFollowers
  - [x] getDealMailMessages
  - [x] getDealParticipants
  - [ ] getDealUsers
  - [x] getDealPersons
  - [x] getDealProducts
  - [x] addDeal
  - [ ] duplicateDeal
  - [x] addDealFollower
  - [x] addDealParticipant
  - [x] addDealProduct
  - [x] updateDeal
  - [ ] mergeDeals
  - [x] updateDealProduct
  - [x] deleteDeals
  - [x] deleteDeal
  - [x] deleteDealFollower
  - [x] deleteDealParticipant
  - [x] deleteDealProduct

- [x] DealFields
  - [x] getDealFields
  - [x] getDealField
  - [x] addDealField
  - [x] updateDealField
  - [x] deleteDealFields
  - [x] deleteDealField

- [ ] Files
  - [x] getFiles
  - [x] getFile
  - [ ] downloadFile
  - [x] addFile
  - [ ] addFileAndLinkIt
  - [ ] linkFileToItem
  - [x] updateFile
  - [x] deleteFile

- [ ] Filters
  - [x] getFilters
  - [ ] getFilterHelpers
  - [x] getFilter
  - [ ] addFilter
  - [ ] updateFilter
  - [ ] deleteFilters
  - [ ] deleteFilter

- [ ] GlobalMessages
  - [ ] getGlobalMessages
  - [ ] deleteGlobalMessage

- [ ] Goals
  - [ ] getGoals
  - [ ] getGoalResult
  - [ ] addGoal
  - [ ] updateGoal
  - [ ] deleteGoal

- [ ] ItemSearch
  - [ ] searchItem
  - [ ] searchItemByField

- [ ] Leads
  - [x] getLeads
  - [x] getLead
  - [x] addLead
  - [ ] deleteLead
  - [ ] updateLead

- [ ] LeadLabels
  - [x] getLeadLabels
  - [ ] addLeadLabel
  - [ ] deleteLeadLabel
  - [ ] updateLeadLabel

- [x] LeadSources
  - [x] getLeadSources

- [ ] Mailbox
  - [ ] getMailMessage
  - [ ] getMailThreads
  - [ ] getMailThread
  - [ ] getMailThreadMessages
  - [ ] updateMailThreadDetails
  - [ ] deleteMailThread

- [x] Notes
  - [x] getNotes
  - [x] getNote
  - [x] addNote
  - [x] updateNote
  - [x] deleteNote

- [x] NoteFields
  - [x] getNoteFields

- [ ] Organizations
  - [x] getOrganizations
  - [x] searchOrganization
  - [x] getOrganization
  - [x] getOrganizationActivities
  - [x] getOrganizationDeals
  - [x] getOrganizationFiles
  - [x] getOrganizationUpdates
  - [x] getOrganizationFollowers
  - [x] getOrganizationMailMessages
  - [ ] getOrganizationUsers
  - [x] getOrganizationPersons
  - [x] addOrganization
  - [x] addOrganizationFollower
  - [x] updateOrganization
  - [ ] mergeOrganizations
  - [x] deleteOrganizations
  - [x] deleteOrganization
  - [x] deleteOrganizationFollower

- [x] OrganizationFields
  - [x] getOrganizationFields
  - [x] getOrganizationField
  - [x] addOrganizationField
  - [x] updateOrganizationField
  - [x] deleteOrganizationFields
  - [x] deleteOrganizationField

- [ ] OrganizationRelationships
  - [ ] getOrganizationRelationShips
  - [ ] getOrganizationRelationship
  - [ ] addOrganizationRelationship
  - [ ] updateOrganizationRelationship
  - [ ] deleteOrganizationRelationship

- [ ] PermissionSets
  - [ ] getPermissionSets
  - [ ] getPermissionSet
  - [ ] getPermissionSetAssignments

- [ ] Persons
  - [x] getPersons
  - [x] searchPersons
  - [x] getPerson
  - [x] getPersonActivities
  - [x] getPersonDeals
  - [x] getPersonFiles
  - [x] getPersonUpdates
  - [x] getPersonFollowers
  - [x] getPersonMailMessages
  - [ ] getPersonUsers
  - [ ] getPersonProducts
  - [x] addPerson
  - [x] addPersonFollower
  - [ ] addPersonPicture
  - [x] updatePerson
  - [ ] mergePersons
  - [x] deletePersons
  - [x] deletePerson
  - [x] deletePersonFollower
  - [ ] deletePersonPicture

- [x] PersonFields
  - [x] getPersonFields
  - [x] getPersonField
  - [x] addPersonField
  - [x] updatePersonField
  - [x] deletePersonFields
  - [x] deletePersonField

- [x] Pipelines
  - [x] getPipelines
  - [x] getPipeline
  - [x] getPipelineConversionStatistics
  - [x] getPipelineDeals
  - [x] getPipelineMovementStatistics
  - [x] addPipeline
  - [x] updatePipeline
  - [x] deletePipeline

- [x] Products
  - [x] getProducts
  - [x] searchProducts
  - [x] getProduct
  - [x] getProductDeals
  - [x] getProductFiles
  - [x] getProductFollowers
  - [x] getProductUsers
  - [x] addProduct
  - [x] addProductFollower
  - [x] updateProduct
  - [x] deleteProduct
  - [x] deleteProductFollower

- [x] ProductFields
  - [x] getProductFields
  - [x] getProductField
  - [x] addProductField
  - [x] updateProductField
  - [x] deleteProductFields
  - [x] deleteProductField

- [ ] Recents
  - [ ] getRecents

- [ ] Roles
  - [ ] getRoles
  - [ ] getRole
  - [ ] getRoleAssignments
  - [ ] getRoleSubRoles
  - [ ] getRoleSettings
  - [ ] addRole
  - [ ] addRoleAssignment
  - [ ] addOrUpdateRoleSetting
  - [ ] updateRole
  - [ ] deleteRole
  - [ ] deleteRoleAssignment

- [x] Stages
  - [x] getStages
  - [x] getStage
  - [x] getStageDeals
  - [x] addStage
  - [x] updateStage
  - [x] deleteStages
  - [x] deleteStage

- [x] Subscriptions
  - [x] getSubscription
  - [x] findSubscriptionByDeal
  - [x] getSubscriptionPayments
  - [x] addRecurringSubscription
  - [x] addSubscriptionInstallment
  - [x] updateRecurringSubscription
  - [x] updateSubscriptionInstallment
  - [x] cancelRecurringSubscription
  - [x] deleteSubscription

- [ ] Teams
  - [ ] getTeams
  - [ ] getTeam
  - [ ] getTeamUsers
  - [ ] getUserTeams
  - [ ] addTeam
  - [ ] addTeamUser
  - [ ] updateTeam
  - [ ] deleteTeamUser

- [ ] Users
  - [x] getUsers
  - [x] findUsersByName
  - [x] getCurrentUser
  - [x] getUser
  - [ ] getUserFollowers
  - [ ] getUserPermissions
  - [ ] getUserRoleAssignments
  - [ ] getUserRoleSettings
  - [x] addUser
  - [ ] addUserRoleAssignment
  - [x] updateUser
  - [ ] deleteUserRoleAssignment

- [ ] UserConnections
  - [ ] getUserConnections

- [ ] UserSettings
  - [ ] getUserSettings

- [x] Webhooks
  - [x] getWebhooks
  - [x] addWebhook
  - [x] deleteWebhook
