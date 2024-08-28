namespace App.Repositories
{
    public class BaseEntity<T>
    {
        public T Id { get; set; } = default!;
    }
}