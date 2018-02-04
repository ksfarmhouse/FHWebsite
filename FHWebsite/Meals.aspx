<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Meals.aspx.cs" Inherits="FHWebsite.Meals" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>FH Meal Sign Up</title>
    <style type="text/css">
        #background{
            background-color: #006938;
        }
        
        .box{
            width: 400px;
            height: 400px;
            
            font-family: Helvetica, Arial, sans-serif;

            background-color: white;
            padding: 2px 20px 2px 20px;
            color: #000;

            position: absolute;
            top: 0;
            right: 0;
            left: 0;
            bottom: 0;
            margin: auto;

            border-width: 5px;
            border-style: solid;
            border-color: #ffce00;
            border-radius: 15px;
            box-shadow: rgba(0,0,0, .75) 0px 0px 20px, rgba(0,0,0, .75) 0px 0px 5px inset;

            max-width: 100%;
            max-height: 100%;
            overflow: auto;
        }

        .box h1{
            color: #006938;
            text-align: center;
        }

        .box input[type=date]{
            width: 124px;
        }

        .box input[type=number]{
            width: 25px;
        }

        .box input[type=submit]{
            background-color: #006938;
            font-size: 18px;
            font-weight: 600;
            color: #ffce00;
            border-radius: 2px;
            border: 1px solid #006938;
            box-shadow: rgba(0,0,0,.75) 0px 0px 4px;
        }

        .box input[type=submit]:hover{
            background-color: #006938;
            color: white;
        } 

        ::-webkit-scrollbar {
            display: none;
        }

    </style>
</head>
<body id="background">
    <form id="form1" runat="server" method="post">
        @{
            var userID;
            var lunch;
            var dinner;
            var date;
            var qty;
    
            if(IsPost){
                userID = Request.Form["userID"];
                lunch = Request.Form["lunch"];
                dinner = Request.Form["dinner"];
                date = Request.Form["date"];
                qty = Request.Form["qty"];

                var db = Database.Open("WebPagesMovies");
                var insertCommand = "INSERT INTO Movies (Title, Genre, Year) Values(@0, @1, @2)";
                db.Execute(insertCommand, title, genre, year);
                Response.Redirect("~/Movies");
            }
        }
        <div class="box">
            <h1>FarmHouse Meal Sign Up</h1>
            <p>
                User ID:&nbsp;<input type="text" name="userID" size="2"/>
            </p>
            <p>Lunch:&nbsp;
                <select name="lunch">
                    <option value="LI">In</option>
                    <option value="LE">Early</option>
                    <option value="LL">Late</option>
                </select>
            </p>
            <p>Dinner:&nbsp;
                <select name="dinner">
                    <option value="DI">In</option>
                    <option value="DE">Early</option>
                    <option value="DL">Late</option>
                </select>
            </p>
            <p>
                Date:&nbsp; <input type="date" name="date" />
            </p>
            <p>
                Quantity:&nbsp; <input type="number" name="qty" />
            </p>
            <input type="submit" name="submit" value="Submit" />
        </div>
    </form>
</body>
</html>
