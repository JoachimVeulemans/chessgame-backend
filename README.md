# Chessgame Backend

## General Summary

This project is a collaboration between Joachim Veulemans and Ian Angillis. The goal of the project is to create a website where you can play games against other people, together, an AI or yourself. You will also be able to replay famous chessgames. This is one of 4 repositories in this project:

- [Chessgame Frontend](https://github.com/JoachimVeulemans/chessgame-frontend)
- [Chessgame Backend](https://github.com/JoachimVeulemans/chessgame-backend)
- [Chessgame AI](https://github.com/JoachimVeulemans/chessgame-ai)
- [Chessgame Database](https://github.com/JoachimVeulemans/chessgame-database)

## Repository Summary

This repository will focus on the backend part of the project. This is written in ASP.NET Core 2.

## Demo

Navigate to [backend.chessgame.jocawebs.be/api](https://backend.chessgame.jocawebs.be/api) to test the website.

## Project Status

Navigate to [Trello]([???]) to view the projects status on Trello.

## Docker Hub Status

Navigate to [Docker Hub Backend](https://hub.docker.com/r/joachimveulemans/chessgame-backend) to view the Docker Hub status.

## Running the project locally

### Using Docker

1. Run `docker build . --file Dockerfile --tag chessgame-backend:latest` to build the image.
2. Run `docker run -d -p 8080:80 chessgame-backend:latest` to start a container. Navigate to `http://localhost:8080/api` to view output.

## Further Information

To get more information, please contact us by creating an issue.