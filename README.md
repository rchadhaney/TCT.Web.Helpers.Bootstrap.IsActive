# TCT.Web.Helpers.Bootstrap.IsActive
IsActive helper for MVC 4+

The Solution contains a simple example project. 
The Actual helper is in the project TCT.Web.Helpers.Bootstrap

The best way to use the helper is:
```html
<li @Html.IsActive("Index", "Home", "class=\"active\"")>@Html.ActionLink("Home", "Index")</li>
```
Note: Even though I created this for MVC 5 projects that utilize Bootstrap there is no requirement 
to use it with Bootstrap. You can use it to inject any html into a page when a view is the active view. 
Also, this "should" work with MVC 4 but I have not tested.

Future: 
	- To extend this to be more generic to handle inserting any kind of content depending on action/controller. 
	- To include in a bootstrap helper library for MVC. 
