# Production
FROM node:alpine

WORKDIR /app

COPY ./package.json ./

RUN npm install -g @quasar/cli
RUN npm install

CMD ["quasar", "build"]