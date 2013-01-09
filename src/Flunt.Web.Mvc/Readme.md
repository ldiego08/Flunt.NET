#Flunt MVC - Fluent Coding For ASP.NET MVC
The Flunt MVC library provides methods and extensions for use with ASP.NET MVC that helps to improve code
readability and maintainability.

##Fluent Web Views
The Flunt MVC library extends the traditional Razor web view engine by adding several methods that allow 
declaration of HTML elements in a fluent manner. 

For example, a text input for a particular model property is declared as follows:

	@Html.TextBoxFor(m => m.ExpirationDate)
	
Until now, it seems simple and readable enough. But things get a little messy as we go further and add 
additional HTML attributes:

	@Html.TextBoxFor(m => m.ExpirationDate, "{0:d}", new { 
			@class = "txt small", 
			style = "margin-right: 20px", 
			placeholder = "dd/mm/yyyy", 
			readonly = "readonly"})
			
It might still seem simple enough for a developer with knowledge of the TextBoxFor method overloads and 
parameters; but with Flunt MVC the previous declaration can be wrote as follows:

	@Html.TextBoxFor(m => m.ExpirationDate).With(
			placeholder:  "dd/mm/yyyy"
			format:       "{0:d}",
			class:        "txt small",
			style:        "margin-right: 20px",
			readonly:     true)
			
Flunt MVC provides, also, direct binding to collections and dictionaries for select lists. With traditional
MVC we would have to write the following code in our view to create a drop-down list:

	@{ 
		var products = ViewBag.Products as IList<Product>  
		var productsListItems = products.Select(p => new SelectListItem 
		{
			Text = p.Name,
			Value = p.Id
		})
	}
	
	@Html.DropDownListFor(m => m.ProductId, productListItems, new { @class = "list dropdown" })
	
With Flunt MVC we could replace the previous piece of code with the following:

	@{ var products = ViewBag.Products as IList<Product> }
	
	@Html.DropDownListFor(m => m.ProductId, withItems: products).With(
		text:   product => product.Name,
		value:  product => product.Id,
		class:  "list dropdown"
	)
	
##Extensible HTML Framework
The Flunt MVC library provides extensibility to allow the developer to create custom HTML content with fluent 
declaration support by using the Flunt HTML Framework.

The classes that compose the framework are located under the Flunt.Web.Mvc.Html namespace. Several components are 
supported out-of-the-box and can be extended to create more complex HTML content. The base components are:

* HtmlBlock: Represents an HTML block containing any kind of valid HTML.
* HtmlElement: Represents an HTML element with CSS class and style attributes.
* HtmlInput: Represents and HTML input element to be used in a form.