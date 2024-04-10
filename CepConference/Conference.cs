
namespace CepConference;

public class Conference
{
    private readonly FeatureToggles _featureToggle;
    private HashSet<String> _attendees = new HashSet<string>();
    private HashSet<String> _hoodies = new HashSet<string>();

    public Conference(FeatureToggles featureToggle = null)
    {
        _featureToggle = featureToggle;
    }

    public bool hoodieIsReserved(string registeredAttendee)
    {
        return _hoodies.Contains(registeredAttendee);
    }

    public bool isRegistered(string attendeeName)
    {
        return _attendees.Contains(attendeeName);
    }

    public void registerAttendees(string nameAttendee)
    {
        _attendees.Add(nameAttendee);

    }

    public void reserveHoodie(string attendeeName)
    {

        if (_featureToggle.IsEnabled("Hoodie"))
        {
            if (_attendees.Contains(attendeeName))
                _hoodies.Add(attendeeName);
        }
    }

    // public int registerAttendees(int attendeesRegistered)
}