# Production
FROM node:alpine

WORKDIR /app

COPY ./package.json ./

RUN npm install -g @quasar/cli
RUN npm install --save-dev quasar-cli@latest
COPY . .

CMD ["quasar", "dev"]

# ! Add nginx!!! CMD ["quasar", "build"]
