FROM        node:alpine

LABEL       author="Your Name"

ENV         NODE_ENV=development 
WORKDIR     /var/www
COPY        . .

RUN         npm install

EXPOSE      3000

ENTRYPOINT  ["npm", "start"]