﻿using FamilyHubs.SharedKernel;
using FamilyHubs.SharedKernel.Interfaces;

namespace FamilyHubs.ServiceDirectoryApi.Core.Entities.OpenReferralReviews;

public class OpenReferralReview : EntityBase<string>, IOpenReferralReview, IAggregateRoot
{
    private OpenReferralReview() { }


    public OpenReferralReview(string id, string openReferralServiceId, string title, string? description, DateTime date, string? score, string? url, string? widget
        )
    {
        Id = id;
        Title = title;
        Description = description;
        Date = date;
        Score = score;
        Url = url;
        Widget = widget;
        OpenReferralServiceId = openReferralServiceId;
    }
    public string Title { get; private set; } = default!;
    public string? Description { get; private set; }
    public DateTime Date { get; private set; }
    public string? Score { get; private set; }
    public string? Url { get; private set; }
    public string? Widget { get; private set; }
    public string OpenReferralServiceId { get; private set; } = default!;

    public void Update(IOpenReferralReview openReferralReview)
    {
        Title = openReferralReview.Title;
        Description = openReferralReview.Description;
        Date = openReferralReview.Date;
        Score = openReferralReview.Score;
        Url = openReferralReview.Url;
        Widget = openReferralReview.Widget;
        OpenReferralServiceId = openReferralReview.OpenReferralServiceId;
    }

}