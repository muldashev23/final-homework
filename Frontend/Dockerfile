FROM node:18.10-alpine AS build

WORKDIR /usr/local/app
COPY  ./ /usr/local/app

RUN npm install
ARG RAILWAY_ENVIRONMENT
RUN if [ "$RAILWAY_ENVIRONMENT" = "production" ] ; then npm run build:production ; else npm run build ; fi ; fi;

FROM nginx:alpine AS ngi
COPY --from=build /usr/local/app/dist/project-frontend /usr/share/nginx/html
COPY nginx.conf /etc/nginx/conf.d/default.conf

EXPOSE 80
