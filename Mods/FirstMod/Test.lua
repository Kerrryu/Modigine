ply = nil
moveSpeed = 10

function Start()
    ply = Modigine.CreateNewGO("LuaPlayer")
    model = Modigine.CreateObjectFromMesh("test", {0.0, 0.0, 0.0})
    model.transform.SetParent(ply.transform)
end

function Update()
    vertical = Input.GetAxis("Vertical")
    horizontal = Input.GetAxis("Horizontal")

    movePos = {0.0, 0.0, 0.0}
    movePos[1] = horizontal * moveSpeed * Time.deltaTime
    movePos[3] = vertical * moveSpeed * Time.deltaTime

    ply.transform.Translate(movePos)
end