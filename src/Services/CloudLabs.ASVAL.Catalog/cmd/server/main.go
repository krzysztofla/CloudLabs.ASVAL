package main

import (
	"log"
	"net/http"
	"os"

	"CloudLabs.ASVAL.Catalog/handlers"
)

func main() {
	logger := log.New(os.Stdout, "items-api", log.LstdFlags)

	mux_server := http.NewServeMux()

	itemsHandler := handlers.ItemsHandlerConstructor(logger)

	mux_server.Handle("/getAllItems", itemsHandler)

	http.ListenAndServe(":8080", mux_server)
}
