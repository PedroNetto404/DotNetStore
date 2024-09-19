using System;

namespace DotNetStore.ApplicationCore.Abstractions;

public abstract class Entity : IEquatable<Entity>
{
    public Guid Id { get; private set; } = Guid.NewGuid();

    public bool Equals(Entity? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;

        return Id == other.Id;
    }

    public override bool Equals(object? obj) => base.Equals(obj);

    public override int GetHashCode() => Id.GetHashCode() * 17;

    public static bool operator ==(Entity? left, Entity? right) =>
        left?.Equals(right) ?? right is null;

    public static bool operator !=(Entity? left, Entity? right) =>
        !(left == right);

    public override string ToString() =>
        $"{GetType().Name} - {Id}";
}
