namespace Pipedrive.Internal
{
    internal class JsonResponse<T>
    {
        public bool Success { get; set; }

        public T Data { get; set; }
    }
}
