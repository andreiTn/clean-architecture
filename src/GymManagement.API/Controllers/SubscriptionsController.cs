using MediatR;
using Microsoft.AspNetCore.Mvc;
using GymManagement.Contracts.Subscriptions;
using GymManagement.Application.Commands.CreateSubscription;
using GymManagement.Application.Commands.GetSubscription;
using DomainSubscriptionType = GymManagement.Domain.Subscriptions.SubscriptionType;

namespace GymManagement.API.Controllers;

[ApiController]
[Route("[controller]")]
public class SubscriptionsController(IMediator mediator) : ControllerBase
{
  private readonly IMediator _mediator = mediator;


  [HttpPost]
  public async Task<IActionResult> CreateSubscription(CreateSubscriptionRequest request)
  {
    if (!DomainSubscriptionType.TryFromName(request.SubscriptionType.ToString(), out var subscriptionType)) {
      return BadRequest();
    }

    var command = new CreateSubscriptionCommand(
      subscriptionType,
      request.AdminId
    );

    var createSubscriptionResult = await _mediator.Send(command);

    return createSubscriptionResult.MatchFirst(
      guid => Ok(new SubscriptionResponse(guid, request.SubscriptionType)),
      error => Problem()
    );
  }

  [HttpGet]
  public async Task<IActionResult> GetSubscription(Guid subscriptionId)
  {
    
    var command = new GetSubscriptionCommand(subscriptionId);
    var createSubscriptionResult = await _mediator.Send(command);

    return createSubscriptionResult.MatchFirst(
      subscription => Ok(new SubscriptionResponse(subscriptionId, SubscriptionType.Free.ToString())),
      error => Problem()
    );
  }
}
