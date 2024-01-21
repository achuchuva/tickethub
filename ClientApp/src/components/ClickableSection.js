function ClickableSection({ id, openSection, currentId }) {

  return (
    <button
      onClick={() => openSection(id)}
      className="clickable-section"
      style={{
        position: 'relative',
        left: (id % 5) * 100 + 'px',
        top: Math.ceil(id / 5) * 100 + 'px',
        backgroundColor: currentId === id ? '#014087' : '#2189ff',
      }}>
      {id}
    </button>
  );
};

export default ClickableSection;
