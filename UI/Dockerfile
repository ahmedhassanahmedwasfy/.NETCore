## Create image based on the official Node 10.5 image from dockerhub
##FROM node:10.15.1
#FROM node:8.11.2-alpine as node
## Create a directory where our app will be placed
#RUN mkdir -p /usr/src/app
#
## Change directory so that our commands run inside this new directory
#WORKDIR /usr/src/app
#
## Copy dependency definitions
#COPY package.json /usr/src/app
#
## Install dependecies
##RUN npm cache clear
#RUN npm install
#
## Get all the code needed to run the app
#COPY . /usr/src/app
#
## Expose the port the app runs in
#EXPOSE 4201
#
#
## Serve the app
#CMD ["npm", "run","build:prod"]


################
###########stage
################
# Stage 0, "build-stage", based on Node.js, to build and compile the frontend
FROM tiangolo/node-frontend:10 as build-stage
WORKDIR /app
COPY package*.json /app/
RUN npm install
COPY ./ /app/
ARG configuration=production
RUN npm run build -- --output-path=./dist/out --configuration $configuration

# Stage 1, based on Nginx, to have only the compiled app, ready for production with Nginx
FROM nginx:1.15
COPY --from=build-stage /app/dist/out/ /usr/share/nginx/html
# Copy the default nginx.conf provided by tiangolo/node-frontend
COPY --from=build-stage /nginx.conf /etc/nginx/conf.d/default.conf
