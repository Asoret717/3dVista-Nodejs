# 3dVista-Nodejs
An example of 3d Vista with Nodejs backend.

![image](https://user-images.githubusercontent.com/81707462/156243280-e1857c50-a52f-4f21-91ed-2bc01807f551.png)

## Description:

After learning unity we have to learn how to use 3dvista and explore if its possible to connect it with nodejs mysql. 
This is for the company ITC(Instituto tecnológico de canarias), the challenge its to make it in a really short time
because the program has a hard license if you don't pay it. (30 days free per computer)

So the app will be a webpage which lets you watch some photos and 360 spaces of Lanzarote, with users that can register, login, make
comments, send messages to the staff and register the views. Not much more because we have to learn how to do this with 3dVista there 
isn't any tutorial for this kind of things.

## Database models:

The first table is used for the login and register, of the users, also for the admins with the attribute "isAdmin", because the admin
and the users can do things than the guests that doesn't log in. The user writes texts and reviews, so they are related, in the texts
we save the user email apart from the id to know where to answer if needed, and in the reviews we save the username to show it in the
reviews view, so other users can see it. Finally everyone make views, while entering each page.

I will make it with XAMPP MySql.

### E/R Model:
![image](https://user-images.githubusercontent.com/81707462/156243975-76131c97-082c-4cc6-80d6-e9512afe11fe.png)



## User requirements:

R1. Plataforma
     
     R1.1. La aplicación va a ser principalmente para web.

R2. Va a tener cuatro funciones esenciales que va a poder realizar el usuario.

R3. Se puede acceder a la aplicación de tres formas: sin registrarse, registrándose como usuario y acceso para administradores.

R4. El registro le permitirá al usuario acceder a otras opciones.

R5. Ser administrador te otorga permisos que no puede realizar un usuario habitualmente.

R6. La aplicación posee ciertas acciones que va a poder realizar el usuario o que la propia aplicación integra al tener contacto con un usuario.

    R6.1 . Un contador de visitas en una esquina del menú que permitirá ver cuántas visitas se ha hecho a dicha aplicación.
    R6.2. Un apartado en el cual el usuario podrá contactar con el servicio de soporte escribiendo un mensaje.
    R.6.3. Un apartado de reseñas en el que el usuario escribirá una reseña acerca de un paseo virtual.
    R.6.4. Un apartado en la aplicación donde podrá registrarse un nuevo usuario o acceder si ya dispone de un registro previo.



## Cases of use:

![image](https://user-images.githubusercontent.com/81707462/156245145-1cc9f8a4-4388-4367-934a-1e17de67db71.png)

Like I said before, guests can watch reviews make views, but you need to be a logged in user to write reviews and messages. Only admins
can manage and watch all the tables.

### UML Model:

![image](https://user-images.githubusercontent.com/81707462/156244795-652ce726-3cdf-4cd7-b177-1f7448e2b58b.png)

### Relational Model:

![image](https://user-images.githubusercontent.com/81707462/156244888-41ec6c07-05fc-4efa-b99f-fa0941e08167.png)



## Description of the operation of the system and technical specifications:

The frontend is made in 3dVista which you can run as a webpage, uses a nodejs backend to manage and connect to the sql database. 

You will need to install node js and other modules in order to make it work, I will talk about it later.

## Interfaces

### Design

#### Prototype:
![image](https://user-images.githubusercontent.com/81707462/156245499-f04768c5-a764-4df6-8a8a-4e3c1a92fdc3.png)

#### Final Screenshots:
![final](https://user-images.githubusercontent.com/81707462/156246521-844a1202-511b-4601-9919-a7f0fdb4241c.png)

### Usability:

After making the app now I will show some of the usability I added.

1-The app is so colorful, with the 3 colors that I repeat in the diferent pages of the project (yellow cyan and gray) as
you can see:

![image](https://user-images.githubusercontent.com/81707462/156246832-3c46d907-69b1-483d-9ec3-818a849551b1.png)

2-The options are intuitive, you can see the buttons clearly without overwhelming the most basic user, as you can see here, in the view with the most
available options, its easy to guess what you could find there.
![image](https://user-images.githubusercontent.com/81707462/156247136-db565b16-254b-42b0-a79b-2a2267ff7fe1.png)


3-The guests are advised to make an account if they want to use the whole usage of the app, they are informed about it.

![image](https://user-images.githubusercontent.com/81707462/156436357-65d71ea8-8635-4aeb-bdcf-41f9a18b4aec.png)

4-When the user starts to register, they will receive advices of what they are doing wrong.

![image](https://user-images.githubusercontent.com/81707462/156436675-8fa31330-885f-465d-8c99-ef6b66ac81da.png)

5-The app shows that the user is logged in, by changing the log in button, and showing the username of the user connected.

![image](https://user-images.githubusercontent.com/81707462/156436791-c1d3242a-e89c-44ba-b58f-38cbbeb5cb0b.png)

6-Other time when he tries the log in again, he will be informed of the mistakes.

![image](https://user-images.githubusercontent.com/81707462/156437061-95acc08a-6ed0-4545-ae51-b2043677c3d8.png)

7-While logged in, the app gives some options to the user, more if he is admin (reports and sql crud).

![image](https://user-images.githubusercontent.com/81707462/156437184-8e1f3d15-e910-4af4-aa9d-e6448f542576.png)

8-Here we can see one of the reports which the admins can make to register the data.

![image](https://user-images.githubusercontent.com/81707462/156248850-f30f9908-8642-4626-8060-8d2696bc340f.png)

9-Guests and everyone can open the help interface to learn how to use the app.

![image](https://user-images.githubusercontent.com/81707462/156437293-7e5c39bc-84c4-4e96-a185-3281a4011ef8.png)

10-The users can send a message to staff, with some advices to notice the errors.

![image](https://user-images.githubusercontent.com/81707462/156437485-b28ba23f-9120-40ae-8a94-ba0d4fc46e3a.png)

11-The virtual reality has a comfortable menu, you can open and close it with just one button. Which is shown to the users, also
the hotspots and arrows to travel to other places have the right size and colors to be seen.

![image](https://user-images.githubusercontent.com/81707462/156249714-f5e21f45-58ef-42dd-a8b0-6cc423427ee6.png)
![image](https://user-images.githubusercontent.com/81707462/156249758-df66a7ef-f8f4-4853-a3e3-7c99da58a0ff.png)
![image](https://user-images.githubusercontent.com/81707462/156249853-3a898091-d91b-4678-81f6-f8fabad9e5cc.png)

## Handbook

### Guide to install

#### Managing the Sql Database

After downloading the git repository, import the sql file to your sql manager. I use XAMPP to use the database.
(Remember, some programs need you to create a database with the same name it is on the file, in this case..)

    db_galdar_3d
XAMPP link: https://www.apachefriends.org/es/download.html
    
![image](https://user-images.githubusercontent.com/81707462/156250096-bf6d2636-d3f0-4cd8-8a03-10a3c964b1ab.png)

![image](https://user-images.githubusercontent.com/81707462/156250153-dd0af5b9-11a8-418e-a605-d38f5709e43d.png)


#### Nodejs Backend

Now you have to run the backend, with visual studio code open the backend folder in the terminal and execute the following
code to get the necessary libraries (I don't upload them to make the file shorter). In order to do this you also need to install
node js.

visual studio code link: https://code.visualstudio.com/download  I use the version 1.63.0
node js link: https://nodejs.org/es/download/  I use the version 6.14.15

    npm install
    npm install cors
    npm install jsreport
    npm install mysql
    npm install express

And when you have everything ready run it.

    npm start

If for some reason you don't have the sql server at the default port 3306, you can change it in this file.

![image](https://user-images.githubusercontent.com/81707462/146056082-e2403dbe-8475-49ff-ab72-dd7f0cbb7f7d.png)

If all went right you should see something like this in the terminal.

![image](https://user-images.githubusercontent.com/81707462/156250351-1c80df9d-e34e-4c0f-9e9c-f28370f66bd3.png)

And this page for example should load (don't try with users, it's protected)

![image](https://user-images.githubusercontent.com/81707462/146056451-06b8d96d-a137-407a-b44d-bc8f536cc5c1.png)

#### 3dVista frontend

If all went right entering this page should load the 3dVista frontend

http://localhost:4000/web3dVista/

![image](https://user-images.githubusercontent.com/81707462/156250572-22cad448-924c-44a4-84ea-9cd2ac223133.png)


3dVista link: https://www.3dvista.com/es/productos/virtual-tour-pro/

![image](https://user-images.githubusercontent.com/81707462/156250675-7f52e111-968e-4e54-860b-c28643d3d7a7.png)


### User guide

Now a basic guide to use the app. (Even that most things are intuitive)

#### Main Menu

In the main menu you can do multiple things:

##### Log in / Register

Clicking the button log in, you can access to the log in and register form. This let you access to more options.
(The app helps you a little in filling the forms correctly)

![image](https://user-images.githubusercontent.com/81707462/156437708-cafa0de6-387f-4ece-9779-4b772ddd27f8.png)

After logging in or resgistering, you can press the new button in the same place to log out.

![image](https://user-images.githubusercontent.com/81707462/156437852-164ed123-a03c-4167-a106-4551b1b65915.png)

##### Views

There is a counter which shows how many times the page has been used.

![image](https://user-images.githubusercontent.com/81707462/156437895-7f9af90c-d135-4c93-9a44-33da06d21ecd.png)

##### Contact

The form to send a message to the staff, only ussable if you are logged in.

![image](https://user-images.githubusercontent.com/81707462/156438008-be555f5c-1c34-472b-8be7-36a103c51d05.png)

#### Virtual reality

The main purpose of the app, also has multiple options:

##### Map

The page where you land at the start, you can choose which place you want to see, this affects the other options.

![image](https://user-images.githubusercontent.com/81707462/156251500-dad989e0-4184-4613-8d5a-5284b9d10465.png)

##### Comments

Here you can watch the comments of other users or make your own if you are logged in.

![image](https://user-images.githubusercontent.com/81707462/156438159-55627343-907c-49ed-b830-d39834c4047b.png)

##### 360 place

The controls are intuitive, and the arrows and hotspots are self-explanatory just click.

![image](https://user-images.githubusercontent.com/81707462/156249758-df66a7ef-f8f4-4853-a3e3-7c99da58a0ff.png)
![image](https://user-images.githubusercontent.com/81707462/156249853-3a898091-d91b-4678-81f6-f8fabad9e5cc.png)



## Technology stack

In this project I use 3dVista, nodejs and XAMPP. (And some unity but it's just a placeholder trial)

I chose nodejs to have this in common with most classmates, in case we needed help. XAMPP because im so used to it but I think
I will learn more about workbench as it seems more comfortable. Finally 3dVista because it makes virtual tours much easier to make.

![image](https://user-images.githubusercontent.com/81707462/156252031-126d55fb-488a-4216-9d90-0436e5ac287a.png)
![image](https://user-images.githubusercontent.com/81707462/156251998-9bb5779a-2e08-493e-b165-a56729535737.png)


## Technology comparison

The company told us to use 3dVista instead of unity, it made the part of the tour so easier that I think that most people
without experience could have made, but the important part of joining sql and code was so limited, you can only use html javascript
in windows on top of the program, that can't affect 3dvista actions, and had to use local storage to try things, but I don't think it's
that save or proffesional to manager accounts with it, I will have to find a different way in the future.

![image](https://user-images.githubusercontent.com/81707462/156253840-fb394fe6-32ed-4c43-ad10-a1b81c411729.png)

## Repositories

I think github is more confortable now, even with 4 branches now.

![image](https://user-images.githubusercontent.com/81707462/156252675-ce06f8a5-e765-4581-9172-7229c860b0ca.png)

## Planification

We had some personal problems at the start, and learning how to use sql with 3dVista without any tutorial or help, just some from the company itself. So
we started so late the project, so to be honest I couldn't finish it in the perfect way I wanted it, it has some appearance mistakes but its more than enough.

We had to plan what to make each day to finish it at time, and the trial of 30 days already expired in our main computers so I could only work at classes, until the
lasts days where I discovered that I could use a virtual machine to use 3dVista, it goes so slow and laggy, it furstrated me but the app its finished. Hope we can improve
it in the future.

## Conclusions, opinions and reflexions

They were right that we needed to learn how to use 3dVista and not just become better at unity, I had to use a lot my mind to figure out how to use sql in javascript
and how to make the interfaces with just some webpage squares. So I think we really learned a lot and we are so prepared for the next challenges, hope it goes even better
at the third time. Now we understand why the company loves 3dVista it makes most of the things for you from the start, the 360 images, controls, hotspots etc everything except
code.

## Links and references

Most of the backend of the app, with the login (even that it's with ionic):

https://github.com/tcrurav/Ionic5NodeAuthBasic

Crud with javascript (Probably the most important tutorial, because the rest was basic things for javascript): 

https://youmightnotneedjquery.com

