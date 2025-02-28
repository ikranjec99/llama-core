# Guide for running llama-local

## Run ollama directly from docker
```
docker run -d -v ollama_data:/root/.ollama -p 11434:11434 --name ollama ollama/ollama:latest_
```

## Pull llama3 model into llama instance
```
docker exec -it ollama ollama pull llama3
```