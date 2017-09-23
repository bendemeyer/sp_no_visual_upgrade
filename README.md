## About this project

There are many cases (particularly for publishing sites) where a site may be migrated from SharePoint 2007 to 2010 without the need for performing the visual upgrade. In fact, if a custom masterpage and page layouts are used, attempting to perform the visual upgrade might result in serious problems.

It's unfortunate then that once a site collection is migrated to 2010, all new sites created within it will be forced to use the version 4 user interface, essentially undergoing the visual upgrade.

This solution puts the choice back into the equation. Just activate the feature on the target site collection and every new subsite created within it will use the version 3 interface, and include the option to upgrade to version 4 if desired. This is accomplished by running an event receiver every time a new site is created that forces the newly created site to run the version 3 UI.

The only side effect I noticed from this solution was that SharePoint tended to assign an incorrect master page to the new site after the UI switch was made. To counter this, the event receiver now forces masterpage inheritance on the new site after the UI switch. Once the site is created, the masterpage assignments can be changed in the site settings as usual.
