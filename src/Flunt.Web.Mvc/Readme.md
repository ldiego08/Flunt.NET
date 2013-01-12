#Flunt MVC - Syntactic Sugar For ASP.NET MVC
The Flunt MVC library provides methods and extensions for use with ASP.NET MVC that helps to improve code
readability and maintainability.

##Fluent Web Views
The Flunt MVC library extends the traditional Razor web view engine by adding several methods that allow 
declaration of HTML elements in a fluent manner, improving readability of Razor view files.

###Form Inputs
In traditional Razor, an HTML text input for a model property is declared as follows:

	@Html.TextBoxFor(m => m.ExpirationDate)
	
Until now, it seems simple and clear enough. But things get a little messy as we go further and add 
additional HTML attributes:

	@Html.TextBoxFor(m => m.ExpirationDate, "{0:d}", new { 
			@class = "txt small", 
			style = "margin-right: 20px", 
			placeholder = "dd/mm/yyyy", 
			readonly = "readonly"})
			
It might still seem simple enough... For a developer with knowledge of the <code>TextBoxFor</code> extension method 
overloads and parameters, that is. With Flunt MVC, however, the previous declaration can be wrote as follows:

	@Html.TextBoxFor(m => m.ExpirationDate).With(
			placeholder:  "dd/mm/yyyy"
			format:       "{0:d}",
			class:        "txt small",
			style:        "margin-right: 20px",
			readonly:     true)
			
###Select Lists And Tables
Flunt MVC also provides helpers that allow rendering of lists and tables without the need of additional markup. For 
example, we would have to write the following code in our view to create a drop-down list:

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
	
In the case of tables, we can render an HTML table using the following code:

	@{ var products = ViewBag.Products as IList<Product> }
	
	@Html.TableFor(products)
	
Or, customize rendered columns:

	@{ var products = ViewBag.Products as IList<Product> }
	
	@Html.TableFor(products).With(
		columns: map => 
			map.Add(product => product.Name)
			   .Add(product => product.ExpirationDate, withFormat: "{0:d}"))
	
##Extensible HTML Framework
The Flunt MVC HTML helper methods are built in top of an highly extensible HTML framework that allows 
to create robust custom helpers with fluent declaration support.

The HTML framework classes are located under the <code>Flunt.Web.Mvc.Html</code> namespace. You can always 
extend any of these classes to create custom HTML content. Built-in base classes are:

*	HtmlBlock: 		Extend to create a custom renderer that will output an HTML markup block.
*	HtmlElement: 	Extend to create a custom renderer that will output an HTML element with optional
							children elements.
*	HtmlInput:		Extend to create a custom renderer that will output an HTML input element to be
							used in a form.