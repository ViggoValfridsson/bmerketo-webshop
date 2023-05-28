# bmerketo-webshop

A mock web-shop created with ASP NET Core and Entity Framework Core as part of my ASP.NET course. 

## About

The database was set up using a code first approach with Entity Framework Core and SQL Server (but can be used with any SQL server). The website uses ASP NET Core identity to handle users and user roles. 
The repository includes a seed file that seeds all categories, tags and over 100 products. The first user to sign up is automatically made into an admin and all subsequent users are given the "user" role. The admin can then add more admins if they wish. All forms contain both client and server side validation.

## How To Run

1. Clone the repository
2. Navigate to the bmerketo-webshop directory and open appsettings.json
3. Change the value of "bmerketo_db" to your connection string
4. Run update-database in the package manager
5. You can now run the application!

### Home Page

| ![home page screenshot](Screenshots/home_page1.PNG) | ![home page screenshot](Screenshots/home_page2.PNG) |
|:---:|:---:|

The home page consists of five parts. A jumbotron showing a random product with the "featured" tag, a collection of products with the "best collection" tag, an on sale section, a top seller section and a newsletter form.

### Products Page

![Products page screenshot](Screenshots/products_desktop.PNG) 

The products page is where you can view all products. There is a menu where you can choose to filter by both tags (featured, on sale etc) and categories (computers, software etc). When a product is clicked you will be taken
to the individual products page. The page also includes pagination both in the URL and with buttons at the bottom of the page.

### Individual Product Page 

![Indivdual product screenshot](Screenshots/individual_product.png) 

### Contact Page 

![home page screenshot](Screenshots/contact_page.PNG) 

### Account Pages 
| ![login page screenshot](Screenshots/signin.PNG) | ![signup page screenshot](Screenshots/signup.PNG) |
|:---:|:---:|

![account overview screenshot](Screenshots/account_overview.PNG) 

### Admin

| ![dashboard products screenshot](Screenshots/dashboard_products.PNG) | ![dashboard users screenshot](Screenshots/dashboard_users.PNG) |
|:---:|:---:|

As an admin you get access to the admin dashboard. The dashboard has options for creating products and handling user roles.

| ![dashboard create products screenshot](Screenshots/dashboard_create.PNG) | ![dashboard update user roles](Screenshots/update_user.PNG) |
|:---:|:---:|

Admins also get access to the edit button when they visit an indivdual products page. The editing functionality has not yet been implemented though.
