# Building the images and add 2 tags for each image
sudo docker build -t bomarconi/quasar-client:latest -t bomarconi/quasar-client:$SHA -f ./client/Dockerfile ./client
sudo docker build -t bomarconi/formbuilder-server:latest -t bomarconi/formbuilder-server:$SHA -f ./R3NextGenBackend/R3NextGenBackend/Dockerfile ./R3NextGenBackend

# Push the images to docker hub
docker push bomarconi/quasar-client:latest
docker push bomarconi/formbuilder-server:latest

push bomarconi/quasar-client:$SHA
push bomarconi/formbuilder-server:$SHA

# Apply the images to kubernetes
kubectl apply -f k8s

# Make sure that we use the latest image for each container
kubectl set image deployments/server-deployment server=bomarconi/formbuilder-server:$SHA
kubectl set image deployments/client-deployment client=bomarconi/quasar-client:$SHA

# Build one image
# docker build -t bomarconi/quasar-client:latest ./client
# docker build -t bomarconi/formbuilder-server:latest ./R3NextGenBackend/R3NextGenBackend
# Push the image to dockerhub
# docker push bomarconi/quasar-client:latest
# docker push bomarconi/formbuilder-server:latest