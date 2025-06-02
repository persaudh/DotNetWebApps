import os
import json
import requests

API_KEY = ""
MOVIE_FILE = "C:\\Users\\persa\\DotNetAndCSharp\\WebApps\\DotNetWebApps\\MovieDirectoryDotNetCoreMVC\\Data\\SeedData\\Movies.json"
SAVE_DIR = "C:\\Users\\persa\\DotNetAndCSharp\\WebApps\\DotNetWebApps\\MovieDirectoryDotNetCoreMVC\\wwwroot\\uploads\\Initial\\"

# Create directory if it doesn't exist
os.makedirs(SAVE_DIR, exist_ok=True)


def load_movies(file_path):
    """Load movies from a JSON file."""
    with open(file_path, "r", encoding="utf-8") as file:
        return json.load(file)


def get_poster_url(title):
    """Get the poster URL for a movie using an API."""
    search_url = "https://api.themoviedb.org/3/search/movie"
    params = {"api_key": API_KEY, "query": title}

    response = requests.get(search_url, params=params);

    if(response.status_code == 200):
        data = response.json()
        results = data.get("results")
        if not results:
            print(f"No results found for {title}")
            return None
        poster_path = results[0].get("poster_path")
        if not poster_path:
            print(f"No poster found for {title}")
            return None
        return f"https://image.tmdb.org/t/p/original{poster_path}"
    return None

def sanitize_filename(title):
    """Sanitize the movie title to create a valid filename."""
    title = title.replace(" ", "-")
    return ''.join(c if c.isalnum() or c in "._-()" else '_' for c in title).strip() + '.jpg'

def download_image(url, file_name):
    """Download an image from a URL and save it to the specified file."""
    try:
        image_data = requests.get(url).content
        with open(os.path.join(SAVE_DIR, file_name), "wb") as file:
            file.write(image_data)
            print(f"Saved: {file_name}")
    except Exception as e:
        print(f"Failed to download {file_name}: {e}")
    


movies = load_movies(MOVIE_FILE)

for movie in movies:
    title = movie.get("Title")
    if title:
        poster_url = get_poster_url(title)
        if poster_url:
            file_name = sanitize_filename(title)
            download_image(poster_url, file_name)