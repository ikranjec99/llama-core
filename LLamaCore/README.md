1. Run ollama directly from docker
<code>
docker run -d -v ollama_data:/root/.ollama -p 11434:11434 --name ollama ollama/ollama:latest_
</code>

2. Pull llama3 model into llama instance
<code>
docker exec -it ollama ollama pull llama3
</code>