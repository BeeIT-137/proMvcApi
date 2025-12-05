FROM node:20

WORKDIR /app

# copy package
COPY package*.json ./
RUN npm install

# copy source
COPY . .

# React dev server
EXPOSE 3000

# Gọi API tới service backend trong docker
ENV REACT_APP_API_URL=http://backend:8080
ENV PORT=3000

CMD ["npm", "start"]
