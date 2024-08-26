using Backend.Domain.Common;

namespace Backend.Domain.Course.Events;

public record CourseCreatedEvent(int CourseId): IDomainEvent;
