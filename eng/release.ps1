heroku container:login

heroku container:push -a convent-webapi web

heroku container:release -a convent-webapi web
