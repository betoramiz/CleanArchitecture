using Clean.Domain.Common;

namespace Clean.Domain.Course.Events;

public record CourseCreatedEvent(int CourseId): IDomainEvent;
