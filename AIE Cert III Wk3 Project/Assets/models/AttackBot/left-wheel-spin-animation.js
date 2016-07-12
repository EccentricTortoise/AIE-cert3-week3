function Update() {
    // Slowly rotate the object around its X axis at 1 degree/second.

    //moving forward + boosting
    if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift)) {
        transform.Rotate(0, Time.deltaTime * 200, 0);
        //Debug.Log("Boosting");
    }
    else if (Input.GetKey(KeyCode.W)) {
        transform.Rotate(0, Time.deltaTime * 100, 0);
        //Debug.Log("Normal Speed");
    }
    //moving backwards + boosting
    if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.LeftShift)) {
        transform.Rotate(0, Time.deltaTime * -200, 0);
    }
    else if (Input.GetKey(KeyCode.S)) {
        transform.Rotate(0, Time.deltaTime * -100, 0);
    }

    //turning
    if (Input.GetKey(KeyCode.D)) {
        transform.Rotate(0, Time.deltaTime * 100, 0);
    }



}