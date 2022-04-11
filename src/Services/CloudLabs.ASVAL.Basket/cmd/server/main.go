package main

import (
	"fmt"
	"github.com/gorilla/mux"
	"net/http"
)

func main() {
	fmt.Println("Welcome to CloudLabs.ASVAL.Basket web api")

}

func handleHttpRequests() {
	router := mux.NewRouter().StrictSlash(true)
	router.HandleFunc("/", returnExampleTestPayload)
}

func returnExampleTestPayload(w http.ResponseWriter, r *http.Request) {
	vars := mux.Vars(r)
	key := vars["id"]
	fmt.Fprintf(w, "Key: "+key)
}
