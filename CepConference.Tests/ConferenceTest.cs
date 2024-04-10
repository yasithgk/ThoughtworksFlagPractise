using System.Runtime.InteropServices.JavaScript;
using NUnit.Framework.Constraints;

namespace CepConference.Tests;

public class ConferenceTest
{
    [Test]
    public void CheckForRegisteredAttendee()
    {
        Conference conference = new();
        conference.registerAttendees("Joe");
        Assert.That(conference.isRegistered("Joe"), Is.True);
    }

    [Test]
    public void CheckforNonRegisteredAttendee()
    {
        Assert.That(new Conference().isRegistered("Aidan"), Is.False);
    }

    [Test]
    public void AttendeeCanReserveAHoodieFeatureOn()
    {
        FeatureToggles featureToggle = new FeatureToggles(new []{"Hoodie"});
        Conference conference = new(featureToggle);
        conference.registerAttendees("Joe");
        conference.reserveHoodie("Joe");
        Assert.That(conference.hoodieIsReserved("Joe"), Is.True);
    }

    [Test]
    public void AttendeeCantReserveAHoodieFeatureOff()
    {
        FeatureToggles featureToggle = new FeatureToggles(new String[]{});
        Conference conference = new(featureToggle);
        conference.registerAttendees("Joe");
        conference.reserveHoodie("Joe");
        Assert.That(conference.hoodieIsReserved("Joe"), Is.False);
    }

    [Test]
    public void NonAttendeeCannotReserveAHoodie()
    {
        FeatureToggles featureToggle = new FeatureToggles(new String[] {});
        Conference conference = new(featureToggle);
        conference.reserveHoodie("Joe");
        Assert.That(conference.hoodieIsReserved("Joe"), Is.False);
    }

    [Test]
    public void AttendeeHasntReservedAHoodie()
    {
        Conference conference = new();
        conference.registerAttendees("Joe");
        Assert.That(conference.hoodieIsReserved("Joe"), Is.False);
    }

}