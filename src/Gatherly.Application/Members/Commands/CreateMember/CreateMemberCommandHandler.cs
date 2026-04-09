using Gatherly.Domain.Entities;
using Gatherly.Domain.Repositories;
using Gatherly.Domain.ValueObjects;
using MediatR;

namespace Gatherly.Application.Members.Commands.CreateMember;

public class CreateMemberCommandHandler : IRequestHandler<CreateMemberCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMemberRepository _memberRepository;

    public CreateMemberCommandHandler(IUnitOfWork unitOfWork, IMemberRepository memberRepository)
    {
        _unitOfWork = unitOfWork;
        _memberRepository = memberRepository;
    }

    public async Task<Unit> Handle(CreateMemberCommand request, CancellationToken cancellationToken)
    {
        var firstNameResult = FirstName.Create(request.FirstName);
        if (firstNameResult.IsFailure)
        {
            //log error
            return Unit.Value;
        }

        var member = new Member(
            Guid.NewGuid(),
            firstNameResult.Value,
            request.LastName,
            request.Email
        );
        _memberRepository.Add(member);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}