namespace Pipedrive
{
    public enum FieldType
    {
        varchar,
        varchar_auto,
        text,
        @double,
        monetary,
        date,
        set,
        @enum,
        user,
        org,
        people,
        phone,
        time,
        timerange,
        daterange,
        @int,
        stage,
        status, // TODO: Can't create deal fields with some types like status
        varchar_options,
        visible_to,
        picture, // Person field
        address // Organization field
    }
}
