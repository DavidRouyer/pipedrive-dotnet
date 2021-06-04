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

You can obtain your secret API key from the API Settings `https://[your organization].pipedrive.com/settings#api` in Pipedrive.

## Debugging

You can debug this library right from your application by configuring the [NuGet symbol server](https://docs.microsoft.com/en-us/nuget/create-packages/symbol-packages-snupkg#nugetorg-symbol-server).

## Supported endpoints

- [ ] Activities
  - [x] getActivities
  - [x] getActivity
  - [x] addActivity
  - [x] updateActivity
  - [ ] deleteActivities
  - [x] deleteActivity

- [x] ActivityFields
  - [x] getActivityFields

- [ ] ActivityTypes
  - [x] getActivityTypes
  - [x] addActivityType
  - [x] updateActivityType
  - [ ] deleteActivityTypes
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
  - [ ] getDealsSummary
  - [ ] getDealsTimeline
  - [x] getDeal
  - [x] getDealActivities
  - [ ] getDealFiles
  - [x] getDealUpdates
  - [x] getDealFollowers
  - [ ] getDealMailMessages
  - [x] getDealParticipants
  - [ ] getDealUsers
  - [ ] getDealPersons
  - [x] getDealProducts
  - [x] addDeal
  - [ ] duplicateDeal
  - [x] addDealFollower
  - [x] addDealParticipant
  - [x] addDealProduct
  - [x] updateDeal
  - [ ] mergeDeals
  - [x] updateDealProduct
  - [ ] deleteDeals
  - [x] deleteDeal
  - [x] deleteDealFollower
  - [x] deleteDealParticipant
  - [x] deleteDealProduct

- [ ] DealFields
  - [x] getDealFields
  - [x] getDealField
  - [x] addDealField
  - [x] updateDealField
  - [ ] deleteDealFields
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
  - [ ] getFilters
  - [ ] getFilterHelpers
  - [ ] getFilter
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
  - [ ] addLead
  - [ ] deleteLead
  - [ ] updateLead

- [ ] LeadLabels
  - [ ] getLeadLabels
  - [ ] addLeadLabel
  - [ ] deleteLeadLabel
  - [ ] updateLeadLabel

- [ ] LeadSources
  - [ ] getLeadSources

- [ ] Mailbox
  - [ ] getMailMessage
  - [ ] getMailThreads
  - [ ] getMailThread
  - [ ] getMailThreadMessages
  - [ ] updateMailThreadDetails
  - [ ] deleteMailThread

- [ ] Notes
  - [x] getNotes
  - [x] getNote
  - [x] addNote
  - [x] updateNote
  - [x] deleteNote

- [ ] NoteFields
  - [ ] getNoteFields

- [ ] Organizations
  - [x] getOrganizations
  - [x] searchOrganization
  - [x] getOrganization
  - [x] getOrganizationActivities
  - [x] getOrganizationDeals
  - [x] getOrganizationFiles
  - [x] getOrganizationUpdates
  - [x] getOrganizationFollowers
  - [ ] getOrganizationMailMessages
  - [ ] getOrganizationUsers
  - [x] getOrganizationPersons
  - [x] addOrganization
  - [x] addOrganizationFollower
  - [x] updateOrganization
  - [ ] mergeOrganizations
  - [ ] deleteOrganizations
  - [x] deleteOrganization
  - [x] deleteOrganizationFollower

- [ ] OrganizationFields
  - [x] getOrganizationFields
  - [x] getOrganizationField
  - [x] addOrganizationField
  - [x] updateOrganizationField
  - [ ] deleteOrganizationFields
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
  - [ ] getPersonDeals
  - [x] getPersonFiles
  - [x] getPersonUpdates
  - [x] getPersonFollowers
  - [ ] getPersonMailMessages
  - [ ] getPersonUsers
  - [ ] getPersonProducts
  - [x] addPerson
  - [x] addPersonFollower
  - [ ] addPersonPicture
  - [x] updatePerson
  - [ ] mergePersons
  - [ ] deletePersons
  - [x] deletePerson
  - [x] deletePersonFollower
  - [ ] deletePersonPicture

- [ ] PersonFields
  - [x] getPersonFields
  - [x] getPersonField
  - [x] addPersonField
  - [x] updatePersonField
  - [ ] deletePersonFields
  - [x] deletePersonField

- [ ] Pipelines
  - [x] getPipelines
  - [x] getPipeline
  - [ ] getPipelineConversionStatistics
  - [x] getPipelineDeals
  - [ ] getPipelineMovementStatistics
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

- [ ] ProductFields
  - [ ] getProductFields
  - [ ] getProductField
  - [ ] addProductField
  - [ ] updateProductField
  - [ ] deleteProductFields
  - [ ] deleteProductField

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

- [ ] Stages
  - [x] getStages
  - [x] getStage
  - [x] getStageDeals
  - [x] addStage
  - [x] updateStage
  - [ ] deleteStages
  - [x] deleteStage

- [ ] Subscriptions
  - [x] getSubscription
  - [x] findSubscriptionByDeal
  - [x] getSubscriptionPayments
  - [x] addRecurringSubscription
  - [x] addSubscriptionInstallment
  - [ ] updateRecurringSubscription
  - [ ] updateSubscriptionInstallment
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