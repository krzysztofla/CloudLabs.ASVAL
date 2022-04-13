package main

import (
	"encoding/json"
	"fmt"
	"github.com/gorilla/mux"
	"io/ioutil"
	"net/http"
)

func returnAll(rw http.ResponseWriter, r *http.Request) {
	response, err := ioutil.ReadAll(r.Body)

	if err != nil {
		http.Error(rw, "Ooops", http.StatusBadRequest)
		return
	}

	fmt.Fprintf(rw, "Data %s", response)
	fmt.Println(err)
	json.NewEncoder(rw).Encode("{}")
}

func main() {
	router := mux.NewRouter().StrictSlash(true)

	router.HandleFunc("/getSomeData", returnAll).Methods("GET")

	http.ListenAndServe(":8080", router)

	fmt.Println("Welcome to CloudLabs.ASVAL.Basket web api")
}
