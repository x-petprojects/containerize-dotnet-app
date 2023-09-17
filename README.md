# containerize-dotnet-app

## cloud-customers

### Installation

Build Docker container:
```
docker build --rm \
-t productive-dev/cloud-customers:latest .
```

Run Docker container:

```
docker run --rm -p 5000:5000 -p 5001:5001 \
-e ASPNETCORE_HTTP_PORT=https://+5001 \
-e ASPNETCORE_URLS=https://+5000 \
productive-dev/cloud-customers
```

#### Deploy Cloud Run

Export variables

```
export REGION={region} &&
export IMAGE={local-docker-image-id} &&
export PROJECT={project-id} &&
export AR={artifact-registry-name} &&
export AR_IMAGE={artifact-registry-container-name}-image
```

1. Create Docker image for Artifact Registry: `docker tag $IMAGE $REGION-docker.pkg.dev/$PROJECT/$AR/$AR_IMAGE`

2. Push Docker image to Artifact Registry: `docker push $REGION-docker.pkg.dev/$PROJECT/$AR/$AR_IMAGE`

3. Create Cloud Run service:

- Expose port: `5000`

- Environment variables:

    |Name|Value|
    |---|---|
    |`ASPNETCORE_HTTP_PORT`|`https://+:5000`|
    |`ASPNETCORE_URLS`|`http://+:5000`|
