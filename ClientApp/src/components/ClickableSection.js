function ClickableSection({ id, openSection }) {

  return (
    <button
      onClick={() => openSection(id)}
      className="clickable-section"
      style={{
        position: 'relative',
        left: (id % 5) * 100 + 'px',
        top: Math.ceil(id / 5) * 100 + 'px'
      }}>
      {id}
    </button>
  );
};

export default ClickableSection;
