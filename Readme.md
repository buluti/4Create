using DDD, CQRS(using MediatR), UnitOfWork

Infrastructure:
	Persistance layer - holding anything Db access related, 
	Infrastructure layer - holding email. notification, message queues....

Presentation:
	Controllers are inside here (outside Web application) so we can enforce the CQRS and DDD architecture 
	when having large amount of models

testing:
	xUnit, FluentAssertion, Moq